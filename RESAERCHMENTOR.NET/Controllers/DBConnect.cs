using System;
using System.Configuration;
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
                mail = new MailMessage(new MailAddress("no-reply@mentorpartner.net", "Research Mentor"), new MailAddress(email));
                mail.Subject = "Registration Confirmation Process For " + user;
                mail.Body = message;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("fbdstest@gmail.com", "p@ssw0rd%%")
                };

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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