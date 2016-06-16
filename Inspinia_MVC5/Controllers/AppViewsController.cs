using Inspinia_MVC5.Models;
using Inspinia_MVC5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inspinia_MVC5.Controllers
{
    public class AppViewsController : Controller
    {

        public static string commName = " ";

        public ActionResult Contacts()
        {
            return View();
        }
     
        public ActionResult Profile()
        {
            return View();
        }


        public ActionResult Contacts2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCommittee(Committee c)
        {

            CreateCommittee newcommittee = new CreateCommittee();
            var committeeName = c.Committee_Name.ToString();
            newcommittee.addCommittee(committeeName);
            System.Diagnostics.Debug.WriteLine(committeeName);
            return View();
        }

        [HttpPost]
        public ActionResult addCommittee(Committee c)
        {
            var committeeName = c.Committee_Name;
            System.Diagnostics.Debug.WriteLine(committeeName);

            CreateCommittee newcommittee = new CreateCommittee();
            newcommittee.addCommittee(committeeName);

            return RedirectToAction("Dashboard_1", "Dashboards");



        }

        public ActionResult Profile2()
        {
            return View();
        }
        
        public ActionResult Projects()
        {
            return View();
        }
       
        public ActionResult ProjectDetail()
        {
            return View();
        }
        
        public ActionResult FileManager()
        {
            return View();
        }
        
        public ActionResult Calendar()
        {
            return View();
        }
        
        public ActionResult FAQ()
        {
            return View();
        }
        
        public ActionResult Timeline()
        {
            return View();
        }
        
        public ActionResult PinBoard()
        {
            return View();
        }

        public ActionResult profile()
        {


            return View();

        }

        public ActionResult TeamsBoard()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            Committee_Details commdetails = new Committee_Details();

            cdashEntities1 _db = new cdashEntities1();
            _db.Database.Connection.Open();
            var username =  ticket.UserData;

            var model = (from mem in _db.committee_Memberlist
                         where mem.Uname_ofMember == username
                         select new Committee_Details()
                         {

                             Committee_Name = mem.name_ofCommittee,
                             Committee_Startdate = mem.member_joindate,
                             Committee_Enddate = mem.memeber_endate,
                             Committee_Active = "yes",
                              numberofpeople = (from com in _db.Committees where
                                               mem.name_ofCommittee == com.Committee_Name
                                               select com.numberofpeople).FirstOrDefault() ?? 0,
                             committee_Memberlist = (from com in _db.Committees
                                                     join com_members in _db.committee_Memberlist on
                                                      mem.name_ofCommittee equals com_members.name_ofCommittee
                                                     select com_members.Uname_ofMember).Distinct().ToList()
                             });






                System.Diagnostics.Debug.WriteLine(model);




                return View(model);
            
        }
        public ActionResult ViewPage1()
        {
            return View();

        }

        public ActionResult SocialFeed()
        {
            return View();
        }

        public ActionResult Clients(String committeeName)
        {
           var commName2 = Request.QueryString["committeeName"].ToString();
           System.Diagnostics.Debug.WriteLine(commName2 + "from2");

            commName =commName2;
            return View();
        }
        public ActionResult addmembertocommittee(String username)
        {
            //var committeeName = Request.QueryString["committeeName"].ToString();

            System.Diagnostics.Debug.WriteLine(commName + "from3");
            add_MemberstoCommittee addm = new add_MemberstoCommittee();
            addm.add(commName, username);

            return RedirectToAction("TeamsBoard", "AppViews");

        }
        public ActionResult OutlookView()
        {
            return View();
        }

        public ActionResult IssueTracker()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Article()
        {
            return View();
        }

        public ActionResult VoteList()
        {
            return View();
        }

	}
}