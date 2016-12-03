using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonTools
{
    public partial class FeedBack : Form
    {
        public FeedBack()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string Content;

            if (Validation(out  Content))
            {
                Mailer.SilentSend("User Given FeedBack ", Content);
                this.Close();
            }
        }

        private bool Validation(out string Content)
        {
            string ErrorMsg = string.Empty;
            StringBuilder Contentbuilder = new StringBuilder();
            if (txtUserName.Text.IsNullorEmpty())
                ErrorMsg += "* User Name is Missing\n";
            Contentbuilder.AppendLine("User : " + txtUserName.Text);

            if (txtEmailID.Text.IsNullorEmpty())
                ErrorMsg += "* User Email is Missing\n";
            Contentbuilder.AppendLine("Email : " + txtEmailID.Text);

            if (txtMobileNo.Text.IsNullorEmpty())
                ErrorMsg += "* User Mobile is Missing\n";
            Contentbuilder.AppendLine("MobileNo : " + txtMobileNo.Text);

            if (rtxtContent.Text.IsNullorEmpty())
                ErrorMsg += "* Description is Missing\n";
            Contentbuilder.AppendLine("Description : " + rtxtContent.Text);

            Content = Contentbuilder.ToString();

            if (ErrorMsg.Length > 0)
            {
                ErrorMsg = "The following Datas Missing Do u Wish to Continue.\n" + ErrorMsg;
                DialogResult result = MessageBox.Show(ErrorMsg, "Warning", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    return true;
                else
                    return false;
            }

            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
