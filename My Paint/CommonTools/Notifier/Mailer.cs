using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Threading;
namespace CommonTools
{
    public class Mailer
    {
        public static bool ShowFeedback()
        {
            FeedBack feedback = new FeedBack();
            feedback.ShowDialog();
            return true;
        }

        public static void SilentSend(string subject, string content, bool displayMessage = false)
        {

            if (displayMessage)
                MessageBox.Show(content);

            try
            {
                StringBuilder essentialData = new StringBuilder();
                essentialData.AppendLine("TimeStamp : " + DateTime.Now.ToString());
                try
                {
                    essentialData.AppendLine("UserName : " + Environment.UserName);
                }
                catch { }
                try
                {
                    essentialData.AppendLine("MachineName : " + Environment.MachineName);
                }
                catch { }
                try
                {
                    essentialData.AppendLine("UserDomainName : " + Environment.UserDomainName);
                }
                catch { }
                try
                {
                    essentialData.AppendLine("OSVersion : " + Environment.OSVersion);
                }
                catch { }
                try
                {
                    essentialData.AppendLine("AssemblyTitle : " + About.AssemblyTitle);
                }
                catch { }
                try
                {
                    essentialData.AppendLine("AssemblyVersion : " + About.AssemblyVersion);
                }
                catch { }
                essentialData.AppendLine("---------------------------");
                essentialData.AppendLine("MessageContent : " + content);


                Thread th = new Thread(() =>
                {
                    SendMail(subject, essentialData.ToString());
                });
                th.Start();

            }
            catch { }

        }

        private static bool SendMail(string subject, string content)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("applicationnotifiermail@gmail.com");
                    mail.To.Add(new MailAddress("muthu.comp13@gmail.com"));
                    mail.Subject = subject;
                    mail.Body = content;
                    mail.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("applicationnotifiermail@gmail.com", "mypass123");
                    smtp.Host = "smtp.gmail.com";
                    smtp.Send(mail);
                    return true;
                }
                catch
                {

                    retryCount++;
                    Thread.Sleep(10000);//Retry after 10 secs.

                    if (retryCount > 3)
                        return false;
                }
            }
        }
    }
}
