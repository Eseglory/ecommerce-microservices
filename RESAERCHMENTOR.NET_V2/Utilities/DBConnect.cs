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
using Microsoft.AspNet.Identity;

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
        public bool MailService(string email, string user, string message, string Subject)
        {
            try
            {
                mail = new MailMessage(new MailAddress("pasosoese@gmail.com", "Mentor Partner"), new MailAddress(email));
                mail.Subject = Subject;
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

    public class UserProperties
    {
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        public List<UserProfile> GetFollowingByLogin(string userName)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    con.Open();
                    string querystring = "select distinct * from Profile as a join Following as b on a.OwnersId = b.OwnerId where a.OwnersId = '" + userName + "'";
                    using (SqlCommand cmd = new SqlCommand(querystring, con))
                    {
                        using (DbDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable("UserProfile");
                            dt.Load(dr);
                            #region Convert To Object List
                            myuserlist = (from DataRow rec in dt.Rows
                                          select new UserProfile()
                                          {
                                              Title = rec["Title"].ToString(),
                                              FName = rec["FName"].ToString(),
                                              LName = rec["LName"].ToString(),
                                              FullName = rec["Title"].ToString() + " " + rec["LName"].ToString() + rec["FName"].ToString(),
                                              Degree = rec["Degree"].ToString(),
                                              CNumber = rec["CNumber"].ToString(),
                                              BDate = rec["BDate"].ToString(),
                                              Gender = rec["Gender"].ToString(),
                                              OwnersId = rec["OwnersId"].ToString(),
                                              DateCreated = rec["DateCreated"].ToString(),
                                              ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                              ProfilePicsName = rec["ConfirmationCode"].ToString(),
                                              Following = rec["Following"].ToString(),
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
            if (myuserlist.Count() > 0)
            {
                foreach (var rec in myuserlist)
                {
                    rec.FName = GetSingleUsersByEmail(rec.Following).FName;
                    rec.LName = GetSingleUsersByEmail(rec.Following).LName;
                }
            }
            return myuserlist;
        }
        public List<UserProfile> GetFellowByLoginList(string userName)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            List<UserProfile> UserList = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Profile as a where a.OwnersId != '" + userName + "' and IsConfirmed = 1";
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
                                              FullName = rec["Title"].ToString() + " " + rec["LName"].ToString() + rec["FName"].ToString(),
                                              Degree = rec["Degree"].ToString(),
                                              CNumber = rec["CNumber"].ToString(),
                                              BDate = rec["BDate"].ToString(),
                                              Gender = rec["Gender"].ToString(),
                                              OwnersId = rec["OwnersId"].ToString(),
                                              DateCreated = rec["DateCreated"].ToString(),
                                              ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                              ProfilePicsName = rec["ProfilePicsName"].ToString(),
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
            myuserlist.Where(x => x.OwnersId != userName);
            return myuserlist;
        }
        public List<UserProfile> GetAllUsers(string userName)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Profile as a where a.OwnersId != '" + userName + "'";
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
                                              DateCreated = rec["DateCreated"].ToString(),
                                              ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                              ProfilePicsName = rec["ProfilePicsName"].ToString(),
                                              IsConfirmed = Convert.ToBoolean(rec["IsConfirmed"].ToString()),
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
            return myuserlist;
        }
        public UserProfile GetSingleUsers(string id)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Profile as a where a.Id = '" + id + "'";
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
                                              OwnersId = rec["OwnersId"].ToString(),
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
        public UserProfile GetSingleUsersByEmail(string id)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Profile as a where a.OwnersId = '" + id + "'";
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
                                              OwnersId = rec["OwnersId"].ToString(),
                                              DateCreated = rec["DateCreated"].ToString(),
                                              ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                              ProfilePicsName = rec["ProfilePicsName"].ToString(),
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
        public List<UserProfile> GetLoginUserResearch(string userName)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct a.Title, a.Degree, a.BDate, a.Country, a.Gender, a.CNumber, a.LName, a.FName, a.ProfilePicsName, b.FileName, b.AuthorName, b.Id, b.DateCreated, b.Description, b.RType, b.Status from Profile as a join Research as b on a.OwnersId = b.OwnersId where a.OwnersId = '" + userName + "' and a.IsConfirmed = 1";
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
                                              Title = rec["Title"].ToString(),
                                              FName = rec["FName"].ToString(),
                                              LName = rec["LName"].ToString(),
                                              Degree = rec["Degree"].ToString(),
                                              CNumber = rec["CNumber"].ToString(),
                                              BDate = rec["BDate"].ToString(),
                                              Gender = rec["Gender"].ToString(),
                                              Country = rec["Country"].ToString(),
                                              ProfilePicsName = rec["ProfilePicsName"].ToString(),
                                              FileName = rec["FileName"].ToString(),
                                              ResearchId = rec["Id"].ToString(),
                                              RDateCreated = rec["DateCreated"].ToString(),
                                              RType = rec["RType"].ToString(),
                                              Status = rec["Status"].ToString(),
                                              Description = rec["Description"].ToString(),

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
            return myuserlist;
        }
        public int AddActivity(Activities model)
        {
            MyModelObjects LoadProfile = new MyModelObjects();
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {                  
                    string creationDate = DateTime.Now.ToShortDateString();
                    var cmd = new SqlCommand("Insert into Activities(ActivityName, ActivityParentID, Type, ActivityDateCreated, OwnerName, Description, Activityowner) values('" + model.ActivityName + "', '" + model.ActivityParentID + "', '" + model.ActivityType + "', '" + creationDate + "', '" + model.OwnerName + "', '" + model.Description + "', '" + model.Activityowner + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    conAm.Close();
                    conAm.Dispose();
                    if (row > 0)
                    {
                        return row;
                    }
                }
                catch (Exception ee)
                {
                    return 0;
                }
            }
            return row;
        }

    }
}