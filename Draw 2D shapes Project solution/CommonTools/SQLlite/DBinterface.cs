using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace CommonTools.SQLlite
{
    public partial class DBinterface : Form
    {
        string connString = "";

        public DBinterface()
        {
            InitializeComponent();
            connString = @"C:\Users\USER\Desktop\temp.db";
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            reader();
        }

        private void btnNonQry_Click(object sender, EventArgs e)
        {
            nonQry();
        }

        private void rtxtQry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                reader();
            }
            else if (e.KeyCode == Keys.F10)
            {
                nonQry();
            }
        }


        void reader()
        {
            try
            {
                string qry = rtxtQry.SelectedText;
                if (qry.IsNullorEmpty())
                {
                    MessageBox.Show("Please select text to Execute");
                    return;
                }

                using (SQLiteHelper liteHelper = new SQLiteHelper(connString))
                {
                    dgvResult.DataSource = liteHelper.GetTable(qry);
                    dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void nonQry()
        {
            try
            {
                string qry = rtxtQry.SelectedText;
                if (qry.IsNullorEmpty())
                {
                    MessageBox.Show("Please select text to Execute");
                    return;
                }

                using (SQLiteHelper liteHelper = new SQLiteHelper(connString))
                {
                    int result = liteHelper.ExecuteNonQuery(qry);
                    MessageBox.Show(string.Format("{0} Rows affected", result));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Stopwatch st = new Stopwatch();
            st.Restart();

            using (SQLiteHelper liteHelper = new SQLiteHelper(connString))
            {
                 liteHelper.BeginTransaction();

                for (int i = 0; i < 50; i++)
                {
                    string qry = "insert into numcheck values(@1)";
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("@1", i);

                    liteHelper.ExecuteNonQuery(qry, SQLiteHelper.GenerateParameter(param), false);
                }

                liteHelper.Commit();
            }
            st.Stop();

            long timespan = st.ElapsedMilliseconds;
            MessageBox.Show("elapsed time " + timespan);
        }
    }
}

