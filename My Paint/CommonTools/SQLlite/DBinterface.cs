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

        public DBinterface()
        {
            InitializeComponent();
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
                string connString, qry;
                bool useAsConnectionString;

                if (GetConnectionString(out connString, out useAsConnectionString, out qry))
                {
                    using (SQLiteHelper liteHelper = new SQLiteHelper(connString, useAsConnectionString))
                    {
                        dgvResult.DataSource = liteHelper.GetTable(qry);
                        dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                    }
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
                string connString, qry;
                bool useAsConnectionString;

                if (GetConnectionString(out connString, out useAsConnectionString, out qry))
                {
                    using (SQLiteHelper liteHelper = new SQLiteHelper(connString, useAsConnectionString))
                    {
                        int result = liteHelper.ExecuteNonQuery(qry, useTransaction: true);
                        MessageBox.Show(string.Format("{0} Rows affected", result));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string path;
            if (FileOperations.GetOpenFilePath(out path, ".DB", "SqlLiteDB"))
            {
                txtDBpath.Text = path;
            }
        }

        private bool GetConnectionString(out string connectionstring, out bool useAsConnectionString, out string qry)
        {
            connectionstring = string.Empty;
            useAsConnectionString = false;

            qry = rtxtQry.SelectedText;
            if (qry.IsNullorEmpty())
            {
                MessageBox.Show("Please select text to Execute");
                return false;
            }
            else
            {
                if (rbtnConnectionString.Checked)
                {
                    connectionstring = txtConnectionString.Text;
                    useAsConnectionString = true;
                }
                else if (rbtnDBpath.Checked)
                {
                    connectionstring = txtDBpath.Text;
                    useAsConnectionString = false;
                }

                if (connectionstring.IsNotNullorEmpty())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid Connection string");
                    return false;
                }
            }
        }

        private void DBinterface_Load(object sender, EventArgs e)
        {
            txtDBpath.Text = SQLiteHelper.ExecutablePathDB;
            rbtnDBpath.Checked = true;
        }
    }
}

