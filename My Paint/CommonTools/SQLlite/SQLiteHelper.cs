using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace CommonTools
{
    public class SQLiteHelper : IDisposable
    {
        private readonly string connecionString = string.Empty;
        private SQLiteConnection connection;

        public SQLiteHelper(string dbpath, bool useAsConnectionString = false)
        {
            if (useAsConnectionString)
            {
                connecionString = dbpath;
            }
            else
            {
                if (!File.Exists(dbpath))
                    throw new Exception("Invalid DB path");

                connecionString = "Data Source = " + dbpath;
            }

            CreateConnection(connecionString);
        }


        public static IEnumerable<SQLiteParameter> GenerateParameter(Dictionary<string, object> parameter)
        {
            List<SQLiteParameter> sqlParam = new List<SQLiteParameter>();
            if (parameter.IsNotNull())
            {
                foreach (KeyValuePair<string, object> eachpair in parameter)
                {
                    sqlParam.Add(new SQLiteParameter(eachpair.Key, eachpair.Value));
                }
            }

            return sqlParam;
        }

        public int ExecuteNonQuery(string qry, IEnumerable<SQLiteParameter> parameters = null, bool useTransaction = true)
        {
            int result = -1;
            using (SQLiteCommand command = CreateCommand(qry, parameters, useTransaction))
            {
                try
                {
                    result = command.ExecuteNonQuery();

                    if (useTransaction)
                        command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (useTransaction)
                        command.Transaction.Rollback();

                    throw;
                }
            }

            return result;
        }


        public T ExecuteScalar<T>(string qry, IEnumerable<SQLiteParameter> parameters = null)
        {
            return (T)ExecuteScalar(qry, parameters);
        }

        public object ExecuteScalar(string qry, IEnumerable<SQLiteParameter> parameters = null)
        {
            using (SQLiteCommand command = CreateCommand(qry, parameters))
            {
                return command.ExecuteScalar();
            }
        }

        public SQLiteDataReader ExecuteReader(string qry, IEnumerable<SQLiteParameter> parameters = null)
        {
            using (SQLiteCommand command = CreateCommand(qry, parameters))
            {
                return command.ExecuteReader();
            }
        }

        public DataTable GetTable(string qry, IEnumerable<SQLiteParameter> parameters = null)
        {
            using (SQLiteCommand command = CreateCommand(qry, parameters))
            {
                DataTable dt = new DataTable();
                SQLiteDataAdapter dataAdapt = new SQLiteDataAdapter(command);
                dataAdapt.Fill(dt);
                return dt;
            }
        }

        
        public void BeginTransaction()
        {
            ExecuteNonQuery("Begin Transaction", useTransaction: false);
        }

        public void Commit()
        {
            ExecuteNonQuery("Commit", useTransaction: false);
        }

        public void RollBack()
        {
            ExecuteNonQuery("RollBack");
        }

        private bool CreateConnection(string connectionstr)
        {
            try
            {
                connection = new SQLiteConnection(connectionstr);
                return openConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Unable Connect check DB path");
                throw;
            }
        }

        private bool openConnection()
        {
            if (connection.IsNull())
                return false;

            if (connection.State == ConnectionState.Open)
                return true;
            else
            {
                connection.Open();
                return true;
            }
        }

        private SQLiteCommand CreateCommand(string qry, IEnumerable<SQLiteParameter> parameters, bool useTransaction = false)
        {
            if (qry.IsNullorEmpty())
                throw new Exception("Query must not be Empty");

            openConnection();

            SQLiteCommand command;

            command = new SQLiteCommand(qry, connection);
            if (useTransaction)
                command.Transaction = connection.BeginTransaction();

            if (parameters != null)
            {
                foreach (SQLiteParameter eachParam in parameters)
                    command.Parameters.Add(eachParam);
            }

            return command;
        }


        public void CloseConnection()
        {
            if (connection.IsNotNull())
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        void IDisposable.Dispose()
        {
            CloseConnection();
        }

        ~SQLiteHelper()
        {
            //this.Dispose();
        }

    }
}
