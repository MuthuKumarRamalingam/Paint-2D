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
            Mailer.SendNotification(rtxtContent.Text);
        }
    }
}
