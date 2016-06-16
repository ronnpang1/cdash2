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
    public class MailboxController : Controller
    {
        cdashEntities1 _db = new cdashEntities1();

        [HttpPost]
        public ActionResult getnumberofinboxmsgs()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;

            int emailcount = (int)(from msg in _db.Inboxes
                        where msg.Recipient == username
                        select new inboxlist_viewmodel
                        {

                            Recipient = msg.Recipient,
                            Sender = msg.Sender,
                            Senddate = msg.Senddate,
                            subject = msg.subject,
                            attachments = msg.attachments


                        }).Count();

            string json = JsonConvert.SerializeObject(emailcount);


            return Json(emailcount);
        }


        public ActionResult Inbox()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;

            var email = from msg in _db.Inboxes
                        where msg.Recipient == username
                        select new inboxlist_viewmodel
                        {
                            ID = msg.ID,
                            Recipient = msg.Recipient,
                            Sender = msg.Sender,
                            Senddate = msg.Senddate,
                            subject = msg.subject,
                            attachments = msg.attachments


                        };
            return View(email);
        }

        public ActionResult EmailView(int msgid,String Read)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;

            if (Read == "read")
            {
                var update = (from msg in _db.Inboxes
                              where msg.ID == msgid

                              select msg).FirstOrDefault();


                if (update != null)
                {
                    update.Read = "read";
                    _db.SaveChanges();
                }
            }

            var email = (from msg in _db.Inboxes
                         where msg.ID == msgid
                         select new EmailViewModel
                        {

                            Recipient = msg.Recipient,
                            Sender = msg.Sender,
                            Senddate = msg.Senddate,
                            Message = msg.Message,
                            subject = msg.subject,
                            attachments = msg.attachments


                        }).FirstOrDefault();

            return View(email);
        }
    
        public ActionResult ComposeEmail(Inbox inbox)
        {
            return View();
        }
    
        public ActionResult EmailTemplates()
        {
            return View();
        }

        public ActionResult BasicActionEmail()
        {
            return View();
        }

        public ActionResult AlertEmail()
        {
            return View();
        }

        public ActionResult BillingEmail()
        {
            return View();
        }
	}
}