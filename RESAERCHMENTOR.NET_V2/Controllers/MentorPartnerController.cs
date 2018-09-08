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
            MyModelObjects LoadProfile = new MyModelObjects();
            LoadProfile = Page_Load();
            string UserName = User.Identity.GetUserName();
            return View(LoadProfile);
        }
        #region Functions
        public MyModelObjects Page_Load()
        {
                MyModelObjects MyObjectList = new MyModelObjects();
                UserProfile UProfile = new UserProfile();
                MyObjectList.FollowCount = GetFellowByLoginList().Count();
                MyObjectList.FollowingCount = GetFollowingByLogin().Count();
                //PictureImageA.ImageUrl = "dist/img/mock1.jpg";
                //Image2.Src = "dist/img/mock1.jpg";
                MyObjectList.MyResearch = GetLoginUserResearch();
                MyObjectList.FollowingList = GetFollowingByLogin();
                MyObjectList.FollowList = GetFellowByLoginList();
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
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        public List<UserProfile> GetFollowingByLogin()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
            if (depositorsList.Count() > 0)
            {
                foreach (var rec in depositorsList)
                {
                    rec.FName = GetSingleUsersByEmail(rec.Following).FName;
                    rec.LName = GetSingleUsersByEmail(rec.Following).LName;
                }
            }
            return depositorsList;
        }
        public List<UserProfile> GetFellowByLoginList()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
            depositorsList.Where(x => x.OwnersId != userName);
            return depositorsList;
        }
        public List<UserProfile> GetAllUsers()
        {
            string userName = User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
                                                  ProfilePicsName = rec["ProfilePicsName"].ToString(),
                                                  IsConfirmed = Convert.ToBoolean(rec["ConfirmationCode"].ToString()),
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
            return depositorsList;
        }
        public UserProfile GetSingleUsers(string id)
        {
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
            return depositorsList.FirstOrDefault();
        }
        public UserProfile GetSingleUsersByEmail(string id)
        {
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
            return depositorsList.FirstOrDefault();
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
            ModelState.AddModelError("UserProfile", "Error Occured");
            return View("UserProfile", LoadProfile);
        }
        public ActionResult UnFollow_Click(string id)
        {
            int FCount = 0;
            if (id != null)
            {
                string Following = GetSingleUsers(id).OwnersId;
                FCount = UnFollowingR(Following);
            }
            else
            {
                ModelState.AddModelError("UserProfile", "Error Occured");
            }
            if (FCount > 0)
            {
                ViewBag.Message = "Operation was successful.";
            }
            return View("UserProfile");
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
                string querystring = "UPDATE [dbo].[Profile] SET [Title] = '" + model.Title + "', [FName] = '" + model.FName + "', [LName] = '" + model.LName + "', [Degree] = '" + model.Degree + "', [CNumber] = '" + model.CNumber + "', [BDate] = '" + model.BDate + "', [Gender] = '" + Gender + "', [ProfilePicsName] = '" + FileName + "' WHERE [OwnersId] = '" + userName + "'";
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
                string path = Server.MapPath("~/Files/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
                ViewBag.Message = "Operation was successful.";
            }
            model.ProfilePicsName = postedFile.FileName;
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
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
            return depositorsList.FirstOrDefault();
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
            List<UserProfile> depositorsList = new List<UserProfile>();
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
                            depositorsList = (from DataRow rec in dt.Rows
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
            return depositorsList;
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
        protected ActionResult AddResearch_Click(UserProfile model, HttpPostedFileBase postedFile)
        {
            MyModelObjects LoadProfile = new MyModelObjects();
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    string path = Server.MapPath("~/Images/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string userName = User.Identity.GetUserName();
                    string creationDate = DateTime.Now.ToShortDateString();
                    string RStatus = "";
                    if (model.RStatus1) { RStatus = "Published"; }
                    else { RStatus = "Draft"; }
                    var cmd = new SqlCommand("Insert into Research(Title, SubTitle, AuthorName, RType, Status, Description, FileName, OwnersId, DateCreated) values('" + model.RTitle + "', '" + model.SubTitle + "', '" + model.AuthorName + "', '" + model.RType + "', '" + RStatus + "', '" + model.Description + "', '" + fileName + "', '" + userName + "', '" + creationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    conAm.Close();
                    conAm.Dispose();
                    if(row > 0)
                    {
                        LoadProfile = Page_Load();
                        ViewBag.Message = "Operation was successful.";
                        return View("UserProfile", LoadProfile);
                    }
                }
                catch (Exception ee)
                {

                }
                return View();
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
    }
}