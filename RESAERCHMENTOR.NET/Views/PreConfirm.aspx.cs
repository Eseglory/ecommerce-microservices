using Microsoft.AspNet.Identity;
using RESAERCHMENTOR.NET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESAERCHMENTOR.NET.Views
{
    public partial class PreConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<UserProfile> GetUserConfirmation(string code)
        {
            List<UserProfile> depositorsList = new List<UserProfile>();
            using (var con = new SqlConnection(ConnectionState()))
            {
                try
                {
                    string query = "";
                    query = "select * from Profile as a where a.ConfirmationCode = '" + code + "' and a.IsConfirmed = 0";
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
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        protected int UpdateUserProfile(string concode)
        {
            int row = 0;
            string userName = Context.User.Identity.GetUserName();
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
        protected void Confirm_Click(object sender, EventArgs e)
        {
            string Ccode = ConCode.Value;
            int Update = 0;
            var CUser = GetUserConfirmation(Ccode);
            if(CUser.Count() > 0)
            {
               Update = UpdateUserProfile(Ccode);
            }
            if(Update > 0)
            {
                Response.Redirect("~/Views/Confirm.aspx");
            }
        }
    }
}