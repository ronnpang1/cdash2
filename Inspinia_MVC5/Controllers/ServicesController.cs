using Inspinia_MVC5.Models;
using Inspinia_MVC5.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inspinia_MVC5.Controllers
{
    public class ServicesController : Controller
    {

        cdashEntities1 _db = new cdashEntities1();

        // GET: Services
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getuserdetails()
        {

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;

            UserViewmodel new_user = new UserViewmodel

            {
                email = username,
                LastName = (from users in _db.users
                            where users.email == username
                            select users.LASTName).First(),
                FirstName = (from users in _db.users
                             where users.email == username
                             select users.FIRSTName).First(),
                Role = (from users in _db.users
                        where users.email == username
                        select users.role).First(),


            };

            string json = JsonConvert.SerializeObject(new_user);



            return Json(json);

        }

        // GET: Services/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Services/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Services/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
