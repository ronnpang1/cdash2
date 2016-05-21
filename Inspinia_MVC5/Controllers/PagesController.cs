using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Inspinia_MVC5.Models;
using Inspinia_MVC5.Services;



namespace Inspinia_MVC5.Controllers
{
    public class PagesController : Controller
    {

        public ActionResult SearchResults()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(user s)
        {
            if (ModelState.IsValid)
            {
                

                    Userservices service = new Userservices();

                    if (service.userexist(s))
                        return RedirectToAction("Register", "Pages");


                    else
                    {
                        service.CreateAccount(s);
                        /* var user = new user
                         {

                             FIRSTName = s.FIRSTName.ToString(),
                             LASTName = s.LASTName.ToString(),
                             email = s.email.ToString(),
                             password= s.password.ToString(),
                             role = s.role.ToString()
                         };
                         //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[users] ON");

                         db.users.Add(user);
                         db.SaveChanges();

                         //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[users] OFF");*/

                        return RedirectToAction("Login_2", "Pages");
                    
                }
            }
            return RedirectToAction("Dashboard_1", "DashBoards");

        }


        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult test1()
        {

            return View();

        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult InvoicePrint()
        {
            return View();
        }

        public ActionResult Validate()
        {
            TempData["error"] = " ";
            var username = Request.Form["Username"].ToString();
            var pw = Request.Form["Password"].ToString();
            var Userservices = new Userservices();
            var role = "admin";

           
           
            if (Userservices.ValidateUser(username,pw))

            {
                bool isPersisted = true;
                usercred user = new usercred();
                user.setuser(username);
                user.setrole("admin");
                var authTicket = new FormsAuthenticationTicket(
                    1,
                    "newcookie",
                    DateTime.Now,
                    DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                    isPersisted,
                    username,
                    FormsAuthentication.FormsCookiePath);

                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                System.Web.HttpCookie Cookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                //var cookie = new HttpCookie("newcookie", encryptedTicket);

                Cookie.Path = FormsAuthentication.FormsCookiePath;
                Cookie.Expires = DateTime.Now.AddYears(1);

                System.Web.HttpContext.Current.Response.Cookies.Add(Cookie);




                return RedirectToAction("Dashboard_1", "Dashboards");
            }


            else
            {
                TempData["error"] = "Invalid Login. Please enter your credentials again.";
                return RedirectToAction("Login_2", "Pages");


            }


        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Login_2()
        {


            ViewBag.Message = TempData["error"];

            return View();
        }

      

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult NotFoundError()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

       
	}
}