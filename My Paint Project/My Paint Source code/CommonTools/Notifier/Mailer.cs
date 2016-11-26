using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace CommonTools
{
    public class Mailer
    {
        public static bool SendNotification(string message, bool displayMessage = false)
        {
            string timeStamp = "TimeStamp " + DateTime.Now.ToString();
            //string user="UserName"+Application.use
            if (displayMessage)
                MessageBox.Show(message);

            try
            {
                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
