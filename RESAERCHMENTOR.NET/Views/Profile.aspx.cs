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

namespace RESAERCHMENTOR.NET.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refreshdata();
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
        
               protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            //ErrorMessage.Text = null;
            //SuccessMessage.Text = null;
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                try
                {
                    //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    //byte[] myFile = FileUpload1.FileBytes;
                    string userName = Context.User.Identity.GetUserName();
                    string CreationDate = DateTime.Now.ToShortDateString();
                    string RGender = "";
                    string DateOfBirth = bday.Value + bmonth.Value + byear.Value;
                    if (Gender1.Checked) { RGender = "Male"; }
                    else { RGender = "Female"; }
                    var cmd = new SqlCommand("Insert into Profile(FirstName, LastName, Degree, Email, Phone, DateOfBirth, Gender, Country, ProfileImage, CreationDate) values('" + FirstName.Value + "', '" + LastName.Value + "', '" + degree.Value + "', '" + userName + "', '" + CNumber.Value + "', '" + DateOfBirth + "', '" + RGender + "', '" + Country.Value + "', '" + null + "', '" + CreationDate + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    //SuccessMessage.Text = "Record was inserted successfully inserted..!";
                    Response.Redirect("SuccessPage.aspx");
                }
                catch (Exception ee)
                {
                    //ErrorMessage.Visible = true;
                    //ErrorMessage.Text = "Sorry. error occured when trying to connect to DB.!";
                    return;
                }
            }
        }



    }
}