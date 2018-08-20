using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using RESAERCHMENTOR.NET.Models;
using System.Data.SqlClient;
using System.Configuration;
using RESAERCHMENTOR.NET.Controllers;

namespace RESAERCHMENTOR.NET.Views
{
    public partial class Register : Page
    {
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }
        protected void InsertUserProfile()
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
                    var cmd = new SqlCommand("INSERT INTO Profile(Title,FName,LName,Degree,CNumber,BDate,Gender,OwnersId,DateCreated,ConfirmationCode) values('" + null + "','" + null + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "', '" + null + "', '" + userName + "','" + CreationDate + "','" + CodeGen + "')", conAm);
                    row = cmd.ExecuteNonQuery();
                    #region Send Confirmation Mail
                    string Message = "";
                    #endregion
                }
                catch (Exception ee)
                {
                    return;
                }
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            ErrorMessage.Text = null;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            #region Check Email
            string emailCheck = Email.Text;
            if (emailCheck.Contains("gmail"))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Sorry you can only use your institution email address";
                return;
            }
            else if (emailCheck.Contains("hotmail"))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Sorry you can only use your institution email address";
                return;
            }
            else if (emailCheck.Contains("livemail"))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Sorry you can only use your institution email address";
                return;
            }
            else if (emailCheck.Contains("yahoo"))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Sorry you can only use your institution email address";
                return;
            }
            else if (emailCheck.Contains("outlook"))
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "Sorry you can only use your institution email address";
                return;
            }
            #endregion
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                InsertUserProfile();
                manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}