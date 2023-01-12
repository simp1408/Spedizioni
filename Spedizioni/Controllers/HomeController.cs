using Spedizioni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Spedizioni.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult Login() => View();
        [HttpPost]
        public ActionResult Login(Utenti u)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["DB_Spedizioni"].ToString();
            connection.Open();
            try {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("Username", u.Username);
                command.Parameters.AddWithValue("Password",u.Password);
                command.CommandText = "Select * from Utenti WHERE Username=@Username AND Password = @Password";
                command.Connection= connection;
                
                SqlDataReader reader= command.ExecuteReader();
                if(reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, false);
                    return Redirect(FormsAuthentication.DefaultUrl);
                }
                else {
                    ViewBag.ErrorMessage = "Username e/o  Password errati";
                }
            
            }catch(Exception ex) 
            {
            
            } finally {
               connection.Close();
            }
            return View();
        }

        public ActionResult LogOut() => Redirect("Login");



    }
}