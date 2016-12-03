using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonTools.SQLlite;

namespace CommonTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Mailer.SilentSend("Common Tools Application Starts", "Some Using application", false);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DBinterface());
            }
            catch (Exception ex)
            {
                Mailer.SilentSend("Exception occurs", ex.ToString(), true);
            }
            Mailer.ShowFeedback();
        }
    }
}
