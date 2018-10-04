using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RESAERCHMENTOR.NET_V2.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using RESAERCHMENTOR.NET.Controllers;
using System.IO;

namespace RESAERCHMENTOR.NET_V2.Controllers
{
    public class MentorPartnerController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public MentorPartnerController()
        {
        }
        public MentorPartnerController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult UserProfile()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");
            }
            MyModelObjects LoadProfile = new MyModelObjects();
            LoadProfile = Page_Load();
            string UserName = User.Identity.GetUserName();
            return View(LoadProfile);
        }
        public ActionResult ResendMail_Click(UserProfile model)
        {
            try
            {
                DBConnect dbconnect = new DBConnect();
                string CCode = GeUser(model.OwnersId).ConfirmationCode;
                #region Send Confirmation Mail
                string Message = "Hello " + model.OwnersId + " your confirmation code is " + CCode + ".";
                Message = Message + " <a href=" + "http://mentorpartner.net/MentorPartner/PreConfirm" + ">click here</a> to proceed";
                var sendmail = dbconnect.ConfirmationMail(model.OwnersId, model.OwnersId, Message);
                if (!sendmail)
                {
                    ViewBag.ErrorText = "Network issue, make sure you are connected to the Internet..!";
                    return View("ResendConfirm", model);
                }
                #endregion
                ViewBag.ErrorText = "Confirmation code was successfully sent to " + model.OwnersId;
                return RedirectToAction("PreConfirm");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorText = "Sorry some thing went wrong..!";
            }
            return RedirectToAction("PreConfirm");
        }
        public ActionResult Confirm_Click(UserProfile model)
        {
            string Ccode = model.ConfirmationCode;
            int Update = 0;
            var CUser = GetUserConfirmation(Ccode);
            if (CUser.Count() > 0)
            {
                Update = UpdateUserProfile(Ccode);
            }
            if (Update > 0)
            {
                return View("Confirm");
            }
            ViewBag.ErrorText = "Code is not correct.!";
            return View("PreConfirm", model);
        }
        public ActionResult ResendConfirm()
        {
            UserProfile model = new Models.UserProfile();
            return View(model);
        }
        public ActionResult PreConfirm()
        {
            UserProfile model = new UserProfile();
            return View(model);
        }
        public ActionResult Confirm()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");
            }
            MyModelObjects LoadProfile = new MyModelObjects();
            LoadProfile.MyResearch = GetLoginUserResearch();
            LoadProfile.GetOtherUsersResearch = GetOtherUsersResearch();
            LoadProfile.MyProfile = GetLoginUser();
            //LoadProfile.MyFullName = GetLoginUser().Title + " " + GetLoginUser().FName + " " + GetLoginUser().LName;
            string UserName = User.Identity.GetUserName();
            return View(LoadProfile);
        }
        public ActionResult UserInfo(string id)
        {
            MyModelObjects LoadProfile = new MyModelObjects();
            string userId = GetSingleUsers(id).OwnersId;
            LoadProfile = Load_Profile(userId);
            string UserName = User.Identity.GetUserName();
            return View(LoadProfile);
        }
        public ActionResult userSearch()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");
            }
            List<UserProfile> LoadProfile = new List<UserProfile>();
            LoadProfile = GetAllUsersAreaOfExpactise("090z");
            string UserName = User.Identity.GetUserName();
            return View(LoadProfile);
        }
        public ActionResult userSearchResult(string fieldExpertise)
        {
            List<UserProfile> LoadProfile = new List<UserProfile>();
            LoadProfile = GetAllUsersAreaOfExpactise(fieldExpertise); ;
            return View("userSearch", LoadProfile);
        }
        public ActionResult UserInbox()
        {
            MyModelObjects MyObjectList = new MyModelObjects();
            MyObjectList.MyMessages = GetLoginUserMessages();
            MyObjectList.MyMessageInbox = GetLoginUserInbox();
            MyObjectList.GetAllUsers = GetAllUsers();
            return View(MyObjectList);
        }
        public ActionResult UserOutbox()
        {
            MyModelObjects MyObjectList = new MyModelObjects();
            MyObjectList.MyMessages = GetLoginUserMessages();
            MyObjectList.MyMessageInbox = GetLoginUserInbox();
            MyObjectList.GetAllUsers = GetAllUsers();
            return View(MyObjectList);
        }
        public ActionResult SendMessage(string id)
        {
            Messages MyObjectList = new Messages();
            string userName = User.Identity.GetUserName();
            MyObjectList.To = GetSingleUsers(id).OwnersId;
            MyObjectList.From = userName;
            return PartialView(MyObjectList);
        }

        #region Functions
        public MyModelObjects Page_Load()
        {
                MyModelObjects MyObjectList = new MyModelObjects();
                UserProfile UProfile = new UserProfile();
                MyObjectList.FollowCount = GetFellowByLoginList().Count();
                MyObjectList.FollowingCount = GetFollowingByLogin().Count();
                MyObjectList.GetAllUsers = GetAllUsers();
                MyObjectList.MyResearch = GetLoginUserResearch();
                MyObjectList.FollowingList = GetFollowingByLogin();
                MyObjectList.FollowList = GetFellowByLoginList();               
                MyObjectList.MyActivities = GetNonLoginUserActivities();
                #region Load Profile
            var MyProfile = GetLoginUser();
                if (MyProfile != null)
                {
                    UProfile.FullName = MyProfile.LName + " " + MyProfile.FName;
                    if (MyProfile.ProfilePicsName != string.Empty)
                    {
                        //PictureImageA.ImageUrl = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                        //Image2.Src = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                    }
                    UProfile.Title = MyProfile.Title;
                    UProfile.FName = MyProfile.FName;
                    UProfile.LName = MyProfile.LName;
                    UProfile.FullName = MyProfile.Title + " " + MyProfile.LName + " " + MyProfile.FName;
                    UProfile.Degree = MyProfile.Degree;
                    UProfile.BDate = MyProfile.BDate;
                    UProfile.CNumber = MyProfile.CNumber;
                    UProfile.Country = MyProfile.Country;
                    UProfile.ProfilePicsName = MyProfile.ProfilePicsName;
                    if (MyProfile.Gender == "Male")
                    {
                     UProfile.Gender1 = true;
                    }
                    else
                    {
                    UProfile.Gender2 = true;
                    }
                }
            #endregion
                MyObjectList.MyProfile = UProfile;
            return MyObjectList;
            }
        public MyModelObjects Load_Profile(string userId)
        {
            UserProperties UProperties = new UserProperties();
            MyModelObjects MyObjectList = new MyModelObjects();
            UserProfile UProfile = new UserProfile();
            MyObjectList.FollowCount = UProperties.GetFellowByLoginList(userId).Count();
            MyObjectList.FollowingCount = UProperties.GetFollowingByLogin(userId).Count();
            MyObjectList.GetAllUsers = GetAllUsers();
            MyObjectList.MyResearch = UProperties.GetLoginUserResearch(userId);
            MyObjectList.FollowingList = UProperties.GetFollowingByLogin(userId);
            MyObjectList.FollowList = UProperties.GetFellowByLoginList(userId);
            #region Load Profile
            var MyProfile = UProperties.GetSingleUsersByEmail(userId);
            if (MyProfile != null)
            {
                UProfile.FullName = MyProfile.LName + " " + MyProfile.FName;
                if (MyProfile.ProfilePicsName != string.Empty)
                {
                    //PictureImageA.ImageUrl = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                    //Image2.Src = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                }
                UProfile.Title = MyProfile.Title;
                UProfile.FName = MyProfile.FName;
                UProfile.LName = MyProfile.LName;
                UProfile.FullName = MyProfile.Title + " " + MyProfile.LName + " " + MyProfile.FName;
                UProfile.Degree = MyProfile.Degree;
                UProfile.BDate = MyProfile.BDate;
                UProfile.CNumber = MyProfile.CNumber;
                UProfile.Country = MyProfile.Country;
                UProfile.ProfilePicsName = MyProfile.ProfilePicsName;
                UProfile.OwnersId = MyProfile.OwnersId;
                if (MyProfile.Gender == "Male")
                {
                    UProfile.Gender1 = true;
                }
                else
                {
                    UProfile.Gender2 = true;
                }
            }
            #endregion
            MyObjectList.MyProfile = UProfile;
            return MyObjectList;
        }
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        public List<UserProfile> GetFollowingByLogin()
        {
            string userName = User.Identity.GetUserName();
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
        public List<UserProfile> GetFellowByLoginList()
        {
            string userName = User.Identity.GetUserName();
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
        public List<UserProfile> GetAllUsers()
        {
            string userName = User.Identity.GetUserName();
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
        public List<UserProfile> GetAllUsersAreaOfExpactise(string param)
        {
            string userName = User.Identity.GetUserName();
            param = "%" + param + "%";
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Profile as a where a.OwnersId != '" + userName + "' and Expertise like '" + param + "'";
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
                                                  Id =  Convert.ToInt32(rec["Id"].ToString()),
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
        protected int FollowingR(string following)
        {
            int row = 0;
            string userName = User.Identity.GetUserName();
            #region Check
            int FollowingList = GetFollowingByLogin().Where(
                x => x.OwnersId == userName && x.Following.Contains(following)).Count();
            if (FollowingList > 0)
            {
                return 0;
            }
            #endregion
            string CodeGen = CodeGenerator.RandomString(7);
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string CreationDate = DateTime.Now.ToShortDateString();
                    var cmd = new SqlCommand("INSERT INTO Following(OwnerId,Following,DateCreated) values('" + userName + "','" + following + "','" + CreationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    return row;
                }
                catch (Exception ee)
                {
                    return 0;
                }
            }
        }
        protected int UnFollowingR(string following)
        {
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    var cmd = new SqlCommand("delete Following where Following = '" + following + "'", conAm);
                    row = cmd.ExecuteNonQuery();
                    return row;
                }
                catch (Exception ee)
                {
                    return 0;
                }
            }
        }
        public ActionResult Follow_Click(string id)
        {
            int FCount = 0;
            MyModelObjects LoadProfile = new MyModelObjects();
            LoadProfile = Page_Load();
            if (id != null)
            {
                string Following = GetSingleUsers(id).OwnersId;
                FCount = FollowingR(Following);
            }
            else
            {
                ModelState.AddModelError("UserProfile", "Error Occured");
            }
            if (FCount > 0)
            {
                ViewBag.Message = "Operation was successful.";
                return View("UserProfile", LoadProfile);
            }
            ModelState.AddModelError("", "Error Occured");
            return View("UserProfile", LoadProfile);
        }
        public ActionResult UnFollow_Click(string id)
        {
            int FCount = 0;
            MyModelObjects LoadProfile = new MyModelObjects();
            LoadProfile = Page_Load();
            if (id != null)
            {
                string Following = GetSingleUsers(id).OwnersId;
                FCount = UnFollowingR(Following);
            }
            else
            {
                ModelState.AddModelError("", "Error Occured");
            }
            if (FCount > 0)
            {
                ViewBag.Message = "Operation was successful.";
            }
            return View("UserProfile", LoadProfile);
        }
        protected int UpdateUserProfile(UserProfile model)
        {
            int row = 0;
            string userName = User.Identity.GetUserName();
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                string Gender = "";
                string FileName = model.ProfilePicsName;
                if (model.Gender1) { Gender = "Male"; }
                else
                {
                    Gender = "Female";
                }
                conAm.Open();
                string querystring = "UPDATE [dbo].[Profile] SET [Title] = '" + model.Title + "',";
                querystring = querystring + "[FName] = '" + model.FName + "', [LName] = '" + model.LName + "',";
                querystring = querystring + "[Degree] = '" + model.Degree + "', [CNumber] = '" + model.CNumber + "',";
                querystring = querystring + "[BDate] = '" + model.BDate + "', [Gender] = '" + Gender + "',";
                querystring = querystring + "[ProfilePicsName] = '" + FileName + "', [WhoYouAre] ='" + model.WhoYouAre + "',";
                querystring = querystring + "[Institution] = '" + model.Institution + "', [Qualification] = '" + model.Qualification +"'";
                querystring = querystring + ", [Expertise] = '" + model.Expertise + "', [Specialty] = '" + model.Specialty +"', ";
                querystring = querystring + "[Interest] = '" + model.Interest + "', [fieldExpertise] = '" + model.fieldExpertise + "',";
                querystring = querystring + " [WillingToBe] = '" + model.WillingToBe + "', [MentorCategory] = '" + model.MentorCategory +"'";
                querystring = querystring + " WHERE[OwnersId] = '" + userName + "'";
                try
                {
                    var cmd = new SqlCommand(querystring, conAm);
                    row = cmd.ExecuteNonQuery();
                    return row;
                }
                catch (Exception ee)
                {
                    return 0;
                }
            }
        }
        public ActionResult UpdateProfile_Click(UserProfile model, HttpPostedFileBase postedFile)
        {
            MyModelObjects LoadProfile = new MyModelObjects();
            if (postedFile != null)
            {
                model.ProfilePicsName = postedFile.FileName;
                string path = Server.MapPath("~/Files/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                ViewBag.Message = "Operation was successful.";
            }
            int FCount = UpdateUserProfile(model);
            if (FCount > 0)
            {
                LoadProfile = Page_Load();
                ModelState.AddModelError("", "Operation was successful");
                return View("UserProfile", LoadProfile);
            }
            return View("UserProfile", LoadProfile);
        }
        public UserProfile GetLoginUser()
        {
            string userName = User.Identity.GetUserName();
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
        public MenTors_Mentees Mentor_Mentee(string mentor)
        {
            string userName = User.Identity.GetUserName();
            List<MenTors_Mentees> myuserlist = new List<MenTors_Mentees>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select * from MenTors_Mentees as a where a.Mentee = '" + userName + "' and Mentor = '"+ mentor + "'";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (DbDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable("UserProfile");
                            dt.Load(dr);
                            #region Convert To Object List
                            myuserlist = (from DataRow rec in dt.Rows
                                          select new MenTors_Mentees()
                                          {
                                              Id = Convert.ToInt32(rec["Id"].ToString()),
                                              Mentee = rec["Mentee"].ToString(),
                                              Mentor = rec["Mentor"].ToString(),
                                              MenTors_MenteesCreated = rec["MenTors_MenteesCreated"].ToString(),                                            
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
        protected void UploadFile()
        {
            try
            {
                string folderPath = Server.MapPath("~/Files/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //PictureUpload.SaveAs(folderPath + Path.GetFileName(PictureUpload.FileName));
                //PictureImageA.ImageUrl = "~/Files/" + Path.GetFileName(PictureUpload.FileName);
                //Image2.Src = "~/Files/" + Path.GetFileName(PictureUpload.FileName);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }
        public List<UserProfile> GetLoginUserResearch()
        {
            string userName = User.Identity.GetUserName();
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
        public List<UserProfile> GetOtherUsersResearch()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct a.Title, a.LName, a.FName, a.ProfilePicsName, b.FileName, b.AuthorName, a.Id, b.Id as ResearchId, b.DateCreated, b.Description, b.RType, b.OwnersId, b.Status from Profile as a join Research as b on a.OwnersId = b.OwnersId join MenTors_Mentees as c on a.OwnersId = c.Mentor where a.OwnersId != '" + userName + "' and c.Mentor != '" + userName + "'";
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
                                              Id = (int) rec["Id"],
                                              Title = rec["Title"].ToString(),
                                              FName = rec["FName"].ToString(),
                                              LName = rec["LName"].ToString(),
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
        public List<UserProfile> GetLoginUserMessages()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Messages where [From] = '" + userName + "'";
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
                                              From = rec["From"].ToString(),
                                              To = rec["To"].ToString(),
                                              Subject = rec["Subject"].ToString(),
                                              Message = rec["Message"].ToString(),
                                              AttachedFileName = rec["AttachedFileName"].ToString(),
                                              MessageDateCreated = rec["MessageDateCreated"].ToString(),                                             

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
        public List<UserProfile> GetLoginUserInbox()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Messages where [To] = '" + userName + "'";
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
                                              From = rec["From"].ToString(),
                                              To = rec["To"].ToString(),
                                              Subject = rec["Subject"].ToString(),
                                              Message = rec["Message"].ToString(),
                                              AttachedFileName = rec["AttachedFileName"].ToString(),
                                              MessageDateCreated = rec["MessageDateCreated"].ToString(),
                                              Read = Convert.ToBoolean(rec["Read"].ToString()),
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
        public List<UserProfile> GetNonLoginUserActivities()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select distinct * from Activities as a join Profile as b on a.Activityowner = b.OwnersId where a.Activityowner != '" + userName + "'";
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
                                              ActivityName = rec["ActivityName"].ToString(),
                                              ActivityParentID = Convert.ToInt32(rec["ActivityParentID"].ToString()),
                                              ActivityType = rec["ActivityType"].ToString(),
                                              ActivityDateCreated = rec["ActivityDateCreated"].ToString(),
                                              OwnerName = rec["OwnerName"].ToString(),
                                              ActivityDescription = rec["Description"].ToString(),
                                              Activityowner = rec["Activityowner"].ToString(),
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
            return myuserlist;
        }
        private void LogError(Exception ex)
        {
            string lines = ex.Message;
            string ErroLog = DateTime.Now.ToLongDateString() + "ErrorLogMentorPartner";
            string mydocpath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, ErroLog + ".txt")))
            {
                outputFile.WriteLine(lines);
            }
        }
        #endregion

        #region Add Research
        public ActionResult AddResearch()
        {
            UserProfile LoadResearch = new UserProfile();
            LoadResearch.OwnersId = GetLoginUser().OwnersId;
            LoadResearch.AuthorName = GetLoginUser().Title + " " + GetLoginUser().FName + " " + GetLoginUser().LName;
            return View("AddResearch", LoadResearch);
        }
        public ActionResult AddResearch_Click(UserProfile model, HttpPostedFileBase postedFile)
        {
            UserProperties userProperties = new UserProperties();
            MyModelObjects LoadProfile = new MyModelObjects();
            Activities loadActivity = new Activities();
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string path = Server.MapPath("~/Images/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    string userName = User.Identity.GetUserName();
                    string creationDate = DateTime.Now.ToShortDateString();
                    string RStatus = "";
                    if (model.RStatus1) { RStatus = "Published"; }
                    else { RStatus = "Published"; }
                    var cmd = new SqlCommand("Insert into Research(Title, SubTitle, AuthorName, RType, Status, Description, FileName, OwnersId, DateCreated) values('" + model.RTitle + "', '" + model.SubTitle + "', '" + model.AuthorName + "', '" + model.RType + "', '" + RStatus + "', '" + model.Description + "', '" + fileName + "', '" + userName + "', '" + creationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    conAm.Close();
                    conAm.Dispose();
                    if(row > 0)
                    {
                        #region Activity
                        loadActivity.ActivityName = "New research was added, " + model.RTitle;
                        loadActivity.ActivityType = "Research";
                        loadActivity.OwnerName = GetSingleUsersByEmail(userName).Title + " " + GetSingleUsersByEmail(userName).LName + " " + GetSingleUsersByEmail(userName).FName;
                        loadActivity.Description = model.SubTitle + " ( " + RStatus + " ) ";
                        loadActivity.Activityowner = userName;
                        #endregion
                        int myActivity = userProperties.AddActivity(loadActivity);
                        LoadProfile = Page_Load();
                        ViewBag.Message = "Operation was successful.";
                        return View("UserProfile", LoadProfile);
                    }
                }
                catch (Exception ee)
                {
                    Response.Write("Error Occurred.!");
                }
                return View("AddResearch");
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase myDoc)
        {
            byte[] MyDocBytes = null;
            BinaryReader reader = new BinaryReader(myDoc.InputStream);
            MyDocBytes = reader.ReadBytes((int)myDoc.ContentLength);
            return MyDocBytes;
        }
        #endregion

        #region Add Post
        public ActionResult AddPost()
        {
            UserProfile LoadResearch = new UserProfile();
            LoadResearch.OwnersId = GetLoginUser().OwnersId;
            LoadResearch.AuthorName = GetLoginUser().Title + " " + GetLoginUser().FName + " " + GetLoginUser().LName;
            return View("AddPost", LoadResearch);
        }
        public ActionResult AddPost_Click(UserProfile model, HttpPostedFileBase postedFile)
        {
            UserProperties userProperties = new UserProperties();
            MyModelObjects LoadProfile = new MyModelObjects();
            Activities loadActivity = new Activities();
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string path = Server.MapPath("~/Images/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    string userName = User.Identity.GetUserName();
                    string creationDate = DateTime.Now.ToShortDateString();
                    string RStatus = "";
                    if (model.RStatus1) { RStatus = "Published"; }
                    else { RStatus = "Published"; }
                    var cmd = new SqlCommand("Insert into Research(Title, SubTitle, AuthorName, RType, Status, Description, FileName, OwnersId, DateCreated) values('" + model.RTitle + "', '" + model.SubTitle + "', '" + model.AuthorName + "', '" + model.RType + "', '" + RStatus + "', '" + model.Description + "', '" + fileName + "', '" + userName + "', '" + creationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    conAm.Close();
                    conAm.Dispose();
                    if (row > 0)
                    {
                        #region Activity
                        loadActivity.ActivityName = "New Post was added, " + model.RTitle;
                        loadActivity.ActivityType = "Post";
                        loadActivity.OwnerName = GetSingleUsersByEmail(userName).Title + " " + GetSingleUsersByEmail(userName).LName + " " + GetSingleUsersByEmail(userName).FName;
                        loadActivity.Description = model.SubTitle + " ( " + RStatus + " ) ";
                        loadActivity.Activityowner = userName;
                        #endregion
                        int myActivity = userProperties.AddActivity(loadActivity);
                        LoadProfile = Page_Load();
                        ViewBag.Message = "Operation was successful.";
                        return View("UserProfile", LoadProfile);
                    }
                }
                catch (Exception ee)
                {
                    Response.Write("Error Occurred.!");
                }
                return View("AddPost");
            }
        }
        #endregion

        #region Send Message
        public ActionResult Messages()
        {
            return View("UserInbox");
        }
        public ActionResult Messages_Click(string OwnersId, string Subject, string Message, HttpPostedFileBase postedFile)
        {
            MyModelObjects LoadProfile = new MyModelObjects();
            DBConnect mailService = new DBConnect();
            int row = 0;
            string fileName = "";
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string path = Server.MapPath("~/Images/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if(postedFile != null)
                    {
                        fileName = Path.GetFileName(postedFile.FileName);
                        postedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    }
                    string userName = User.Identity.GetUserName();
                    string creationDate = DateTime.Now.ToShortDateString();                   
                    var cmd = new SqlCommand("Insert into Messages([From], [To], [Subject], [Message], [AttachedFileName], [MessageDateCreated], [Read]) values('" + userName + "', '" + OwnersId + "', '" + Subject + "', '" + Message + "', '" + fileName + "', '" + creationDate + "', '" + false + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    conAm.Close();
                    conAm.Dispose();
                    string message = "You have a pending message on mentor partner, please login to reply.";
                    if (row > 0)
                    {
                        mailService.MailService(OwnersId, OwnersId, message, Subject);
                        LoadProfile = Page_Load();
                        ViewBag.Message = "Operation was successful.";
                        return View("UserProfile", LoadProfile);
                    }
                }
                catch (Exception ee)
                {
                    Response.Write("Error Occurred.!");
                }
                return View("UserProfile", LoadProfile);
            }
        }
        #endregion

        #region Add Mentor
        public ActionResult Mentor_Click(string id)
        {
            MyModelObjects LoadProfile = new MyModelObjects();
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string mentor = GetSingleUsers(id).OwnersId;
                    string MentorName = GetSingleUsersByEmail(mentor).Title + " " + GetSingleUsersByEmail(mentor).LName + " " + GetSingleUsersByEmail(mentor).FName;
                    var SeeId = Mentor_Mentee(mentor);
                    if(SeeId != null)
                    {
                        LoadProfile = Page_Load();
                        ViewBag.Message = "This  Person Is Already Your Mentor.";
                        return View("UserProfile", LoadProfile);
                    }
                    string userName = User.Identity.GetUserName();
                    string creationDate = DateTime.Now.ToShortDateString();
                    var cmd = new SqlCommand("Insert into MenTors_Mentees(Mentor, Mentee, MenTors_MenteesCreated) values('" + mentor + "', '" + userName + "', '" + creationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    conAm.Close();
                    conAm.Dispose();
                    if (row > 0)
                    {
                        LoadProfile = Page_Load();
                        ViewBag.Message = "Operation was successful." + " " + MentorName + " is now your mentor.";
                        return View("UserProfile", LoadProfile);
                    }
                }
                catch (Exception ee)
                {
                    Response.Write("Error Occurred.!");
                }
                return View("UserProfile", LoadProfile);
            }
        }
        #endregion

        #region Pre-Confirmation Functions
        public List<UserProfile> GetUserConfirmation(string code)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select * from Profile as a where a.ConfirmationCode = '" + code + "'";
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
                                                  OwnersId = rec["OwnersId"].ToString(),
                                                  DateCreated = rec["DateCreated"].ToString(),
                                                  ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                                  ProfilePicsName = rec["ConfirmationCode"].ToString(),
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
        protected int UpdateUserProfile(string concode)
        {
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                string ConDate = DateTime.Now.ToShortDateString();
                conAm.Open();
                string querystring = "UPDATE [dbo].[Profile] SET [IsConfirmed] = 1, [ConfirmDate] = '" + ConDate + "' WHERE [ConfirmationCode] = '" + concode + "'";
                try
                {
                    var cmd = new SqlCommand(querystring, conAm);
                    row = cmd.ExecuteNonQuery();
                    return row;
                }
                catch (Exception ee)
                {
                    return 0;
                }
            }
        }
        public UserProfile GeUser(string Email)
        {
            List<UserProfile> myuserlist = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select * from Profile as a where a.OwnersId = '" + Email + "'";
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
                                                  OwnersId = rec["OwnersId"].ToString(),
                                                  DateCreated = rec["DateCreated"].ToString(),
                                                  ConfirmationCode = rec["ConfirmationCode"].ToString(),
                                                  ProfilePicsName = rec["ConfirmationCode"].ToString(),
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

        #endregion

        #region Terms and Condition
        public ActionResult TermsAndConditions()
        {
            return View();
        }

        #endregion

        #region About Us
        public ActionResult AboutUs()
        {
            return View();
        }

        #endregion
    }
}