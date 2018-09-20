using RESAERCHMENTOR.NET_V2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
        public UserProfile GetLoginUser(string userName)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select * from Profile as a where a.OwnersId = '" + userName + "'";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (DbDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable("UserProfile");
                            dt.Load(dr);
                            #region Convert To Object List
                            myuserlist = (from DataRow rec in dt.Rows
                                          select new UserProfile()
                                          {
                                              Id = Convert.ToInt32(rec["Id"].ToString()),
                                              Title = rec["Title"].ToString(),
                                              FName = rec["FName"].ToString(),
                                              LName = rec["LName"].ToString(),
                                              Degree = rec["Degree"].ToString(),
                                              CNumber = rec["CNumber"].ToString(),
                                              BDate = rec["BDate"].ToString(),
                                              Gender = rec["Gender"].ToString(),
                                              OwnersId = rec["OwnersId"].ToString(),
                                              Country = rec["Country"].ToString(),
                                              DateCreated = rec["DateCreated"].ToString(),
                                              ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                              ProfilePicsName = rec["ProfilePicsName"].ToString(),
                                              WhoYouAre = rec["WhoYouAre"].ToString(),
                                              Institution = rec["Institution"].ToString(),
                                              Qualification = rec["Qualification"].ToString(),
                                              Expertise = rec["Expertise"].ToString(),
                                              Specialty = rec["Specialty"].ToString(),
                                              Interest = rec["Interest"].ToString(),
                                              fieldExpertise = rec["fieldExpertise"].ToString(),
                                              WillingToBe = rec["WillingToBe"].ToString(),
                                              MentorCategory = rec["MentorCategory"].ToString(),

                                          }).ToList();
                            #endregion
                        }
                        con.Close();
                        con.Dispose();
                    }
                }
                catch (Exception ee)
                {
                    var message = ee.Message;
                }
            }
            return myuserlist.FirstOrDefault();
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