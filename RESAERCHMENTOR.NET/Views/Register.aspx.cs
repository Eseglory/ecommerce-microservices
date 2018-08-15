using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using RESAERCHMENTOR.NET.Models;

namespace RESAERCHMENTOR.NET.Views
{
    public partial class Register : Page
    {
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