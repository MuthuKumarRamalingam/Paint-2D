using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CommonTools.SQLlite
{
    public partial class DBinterface : Form
    {
        string connString = "";

        public DBinterface()
        {
            InitializeComponent();
            connString = @"Data Source=C:\Users\USER\Desktop\temp.db";
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            reader();
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

                SQLiteHelper liteHelper = new SQLiteHelper(connString);
                dgvResult.DataSource = liteHelper.GetTable(qry);
                dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNonQry_Click(object sender, EventArgs e)
        {
            nonQry();
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

                SQLiteHelper liteHelper = new SQLiteHelper(connString);
                int result = liteHelper.ExecuteNonQuery(qry);

                MessageBox.Show(string.Format("{0} Rows affected", result));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
    }
}

