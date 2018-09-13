using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using MailMessage = System.Net.Mail.MailMessage;

namespace RESAERCHMENTOR.NET.Controllers
{
    public class DBConnect
    {
        private MailMessage mail;
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        public bool ConfirmationMail(string email, string user, string message)
        {
            try
            {
                mail = new MailMessage(new MailAddress("pasosoese@gmail.com", "Mentor Partner"), new MailAddress(email));
                mail.Subject = "Registration Confirmation Process For " + user;
                mail.Body = message;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient
                {
                    //Host = "mail.mentorpartner.net",
                    //Port = 465,
                    //EnableSsl = true,
                    //DeliveryMethod = SmtpDeliveryMethod.Network,
                    //UseDefaultCredentials = false,
                    //Timeout = 9999,
                    //Credentials = new NetworkCredential("noreply@mentorpartner.net", "Mentorpartner2018")
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("pasosoese@gmail.com", "eseosa@1212")
                };

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            return true;
        }
        private void LogError(Exception ex)
        {
            string lines = ex.Message;
            string ErroLog = DateTime.Now.ToLongDateString() + "ErrorLogMentoPartner";
            string mydocpath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "WriteLines.txt")))
            {
                    outputFile.WriteLine(lines);
            }
        }
    }
    public static class CodeGenerator
    {
        private static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string RandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}