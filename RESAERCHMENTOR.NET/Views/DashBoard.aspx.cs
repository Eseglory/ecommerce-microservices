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
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GetLoginUser();
                RProfileImg.Src = "dist/img/big/prof-px.png";
                #region Load Profile
                var MyProfile = GetLoginUser().FirstOrDefault();
                if (MyProfile != null)
                {
                    if (MyProfile.ProfilePicsName != string.Empty)
                    {
                       RProfileImg.Src = "~/Files/" + Path.GetFileName(MyProfile.ProfilePicsName);
                    }
                    ROwner.Text = MyProfile.LName + " " + MyProfile.FName;
                    
                }
                #endregion
            }
        }
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
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
    }
}