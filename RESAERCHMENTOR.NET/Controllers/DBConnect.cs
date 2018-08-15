using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RESAERCHMENTOR.NET.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace RESAERCHMENTOR.NET.Controllers
{
    public class DBConnect
    {
        private string ConnectionState()
        {
            string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return conString;
        }

    }
}