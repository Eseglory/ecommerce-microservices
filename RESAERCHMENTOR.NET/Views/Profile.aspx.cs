using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RESAERCHMENTOR.NET.Controllers;
using System.Configuration;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Data;
using RESAERCHMENTOR.NET.Models.Entities;
using System.Data.Common;

namespace RESAERCHMENTOR.NET.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int CFollow = GetFellowByLoginList().Count();
            int CFollowing = GetFollowingByLogin().Count();

            if (!Page.IsPostBack)
            {
                PictureImageA.ImageUrl = "dist/img/mock1.jpg";
                Image2.Src = "dist/img/mock1.jpg";
                LabelFollow.Text = CFollow.ToString();
                LabelFollowing.Text = CFollowing.ToString();
                refreshdata();
                GetFollowingByLogin();
                GetFellowByLoginList();
                #region Load Profile
                var MyProfile = GetLoginUser().FirstOrDefault();
                if (MyProfile != null)
                {
                    if(MyProfile.ProfilePicsName != string.Empty)
                    {
                        PictureImageA.ImageUrl = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                        Image2.Src = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                    }
                    Rtitle.Value = MyProfile.Title;
                    FirstName.Value = MyProfile.FName;
                    LastName.Value = MyProfile.LName;
                    degree.Value = MyProfile.Degree;
                    BDate.Value = MyProfile.BDate;
                    CNumber.Value = MyProfile.CNumber;
                    Country.Value = MyProfile.Country;
                    if (MyProfile.Gender == "Male")
                    {
                        Gender1.Checked = true;
                    }
                    else
                    {
                        Gender2.Checked = true;
                    }
                    Email.Value = MyProfile.OwnersId;

                    first_name2.Value = MyProfile.FName;
                    last_name2.Value = MyProfile.LName;
                    degree2.Value = MyProfile.Degree;
                    CNumber2.Value = MyProfile.CNumber;
                    BDate2.Value = MyProfile.BDate;
                    Country2.Value = MyProfile.Country;
                    if (MyProfile.Gender == "Male")
                    {
                        Gender11.Checked = true;
                    }
                    else
                    {
                        Gender22.Checked = true;
                    }
                    Email2.Value = MyProfile.OwnersId;
                }
                #endregion
            }
        }
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        public void refreshdata()
        {
            SqlConnection con = new SqlConnection(ConnectionState());
            SqlCommand cmd = new SqlCommand("select * from Research", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public List<UserProfile> GetFollowingByLogin()
        {
            string userName = Context.User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    con.Open();
                    string querystring = "select distinct * from Profile as a join Following as b on a.OwnersId = b.OwnerId where a.OwnersId = '"+ userName + "'";
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
            return depositorsList;
        }
        public List<UserProfile> GetFellowByLoginList()
        {
            string userName = Context.User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    List<UserProfile> UserKist = new List<UserProfile>();
                    string query = "";
                    query = "select distinct * from Profile as a where not exists ( select * from Following as b) and a.OwnersId != '" + userName + "'";
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
            depositorsList.Where(x => x.OwnersId != userName);
            return depositorsList;
        }
        public List<UserProfile> GetAllUsers()
        {
            string userName = Context.User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";                 
                    query = "select * from Profile as a";
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
                                                  ProfilePicsName = rec["ConfirmationCode"].ToString(),
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
        protected int FollowingR(string following)
        {
            int row = 0;
            string CodeGen = CodeGenerator.RandomString(7);
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    string userName = Context.User.Identity.GetUserName();
                    string CreationDate = DateTime.Now.ToShortDateString();
                    var cmd = new SqlCommand("INSERT INTO Following(OwnerId,Following,DateCreated) values('" + userName + "','" + following + "','" + CreationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    return row;
                    #region Send Confirmation Mail
                    string Message = "";
                    #endregion
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
                    var cmd = new SqlCommand("delete Following where Following = '"+ following + "'", conAm);
                    row = cmd.ExecuteNonQuery();
                    return row;
                }
                catch (Exception ee)
                {
                    return 0;
                }
            }
        }
        protected void Follow_Click(object sender, EventArgs e)
        {
            string Following = Session["passFid"].ToString();
            int FCount = FollowingR(Following);
            if(FCount > 0)
            {
                Response.Redirect("SuccessPage.aspx");
            }
        }
        protected void UnFollow_Click(object sender, EventArgs e)
        {
            string Following = Session["passFid"].ToString();
            int FCount = UnFollowingR(Following);
            if (FCount > 0)
            {
                Response.Redirect("SuccessPage.aspx");
            }
        }
        protected int UpdateUserProfile()
        {
            int row = 0;
            string userName = Context.User.Identity.GetUserName();
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                string Gender = "";
                string FileName = PictureUpload.FileName;
                if (Gender1.Checked) { Gender = "Male"; }
                else
                {
                    Gender = "Female";
                }
                conAm.Open();
                string querystring = "UPDATE [dbo].[Profile] SET [Title] = '"+ Rtitle.Value +"', [FName] = '"+ FirstName.Value +"', [LName] = '"+ LastName.Value +"', [Degree] = '"+ degree.Value +"', [CNumber] = '"+ CNumber.Value +"', [BDate] = '"+ BDate.Value +"', [Gender] = '"+ Gender + "', [ProfilePicsName] = '" + FileName + "' WHERE [OwnersId] = '"+ userName + "'";
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
        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            UploadFile();
            int FCount = UpdateUserProfile();
            if (FCount > 0)
            {
                Response.Redirect("SuccessPage.aspx");
            }
        }
        public List<UserProfile> GetLoginUser()
        {
            string userName = Context.User.Identity.GetUserName();
            List<UserProfile> depositorsList = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select * from Profile as a where a.OwnersId = '" + userName + "' and a.IsConfirmed = 1";
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
            return depositorsList;
        }
        protected void UploadFile()
        {
            string folderPath = Server.MapPath("~/Files/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            PictureUpload.SaveAs(folderPath + Path.GetFileName(PictureUpload.FileName));
            PictureImageA.ImageUrl = "~/Files/" + Path.GetFileName(PictureUpload.FileName);
            Image2.Src = "~/Files/" + Path.GetFileName(PictureUpload.FileName);
        }

    }
}