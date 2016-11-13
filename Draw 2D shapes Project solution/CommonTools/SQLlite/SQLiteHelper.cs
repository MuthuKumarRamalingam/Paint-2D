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
    public class SQLiteHelper
    {
        private static string connecionString = string.Empty;

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
        }

        private static SQLiteConnection CreateConnection(string connectionstr)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(connectionstr);
                return connection.OpenAndReturn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable Connect check DB path", ex.ToString());
                return null;
            }
        }

        private static SQLiteCommand CreateCommand(SQLiteConnection connection, string qry, List<SQLiteParameter> parameters = null)
        {
            SQLiteCommand command = new SQLiteCommand(qry, connection);

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Count; i++)
                    command.Parameters.Add(parameters[i]);
            }

            return command;
        }


        public object ExecuteScalar(string qry, List<SQLiteParameter> parameters = null)
        {
            object result = null;

            using (SQLiteConnection connection = CreateConnection(connecionString))
            {
                using (SQLiteCommand command = CreateCommand(connection, qry, parameters))
                {
                    result = command.ExecuteScalar();
                    command.Dispose();
                }

                connection.Close();
            }

            return result;
        }

        public SQLiteDataReader ExecuteReader(string qry, List<SQLiteParameter> parameters = null)
        {
            using (SQLiteConnection connection = CreateConnection(connecionString))
            {
                using (SQLiteCommand command = CreateCommand(connection, qry, parameters))
                {
                    return command.ExecuteReader();
                }
            }
        }

        public int ExecuteNonQuery(string qry, List<SQLiteParameter> parameters = null)
        {
            int result = -1;
            using (SQLiteConnection connection = CreateConnection(connecionString))
            {
                using (SQLiteCommand command = CreateCommand(connection, qry, parameters))
                {
                    result = command.ExecuteNonQuery();
                    command.Dispose();
                }
                connection.Close();
            }
            return result;
        }

        public DataTable GetTable(string qry, List<SQLiteParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection connection = CreateConnection(connecionString))
            {
                using (SQLiteCommand command = CreateCommand(connection, qry, parameters))
                {
                    SQLiteDataAdapter dataAdapt = new SQLiteDataAdapter(command);
                    dataAdapt.Fill(dt);
                    command.Dispose();
                }
                connection.Close();
            }

            return dt;
        }

    }
}
