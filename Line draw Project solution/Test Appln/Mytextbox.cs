using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Appln
{
    public class Mytextbox : TextBox
    {
        public Mytextbox()
        {
            this.Text = "myxty";
            this.Enabled = false;
        }
    }
}
