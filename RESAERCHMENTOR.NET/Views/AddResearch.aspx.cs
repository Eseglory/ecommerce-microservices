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

namespace RESAERCHMENTOR.NET.Views
{
    public partial class AddResearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new ListItem(fileName, "~/Images/" + fileName));
                }
            }
        }
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        protected void AddResearch_Click(object sender, EventArgs e)
        {
            ErrorMessage.Text = null;
            SuccessMessage.Text = null;
            int row = 0;
            using (SqlConnection conAm = new SqlConnection(ConnectionState()))
            {
                conAm.Open();
                 try
                    {
                        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);                        
                        byte[] myFile = FileUpload1.FileBytes;
                        string userName = Context.User.Identity.GetUserName();
                        string creationDate = DateTime.Now.ToShortDateString();
                        string RStatus = "";
                        if (RStatus1.Checked) { RStatus = "Published"; }
                        else { RStatus = "Draft"; }
                        var cmd = new SqlCommand("Insert into Research(Title, SubTitle, AuthorName, RType, Status, Description, FileName, OwnersId, DateCreated) values('"+ ReTitle.Value +"', '" + ReSubTitle.Value + "', '" + ReAuthorName.Value + "', '" + ReType1.Value + "', '" + RStatus + "', '" + ReDescription.Value + "', '" + fileName + "', '" + userName + "', '" + creationDate + "')", conAm);
                        row = cmd.ExecuteNonQuery();
                        SuccessMessage.Text = "Record was inserted successfully inserted..!";
                        Response.Redirect("SuccessPage.aspx");
                    }
                    catch (Exception ee)
                    {
                        ErrorMessage.Visible = true;
                        ErrorMessage.Text = "Sorry. error occured when trying to connect to DB.!";
                        return;
                   }
            }
        }
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase myDoc)
        {
            byte[] MyDocBytes = null;
            BinaryReader reader = new BinaryReader(myDoc.InputStream);
            MyDocBytes = reader.ReadBytes((int)myDoc.ContentLength);
            return MyDocBytes;
        }
    }
}