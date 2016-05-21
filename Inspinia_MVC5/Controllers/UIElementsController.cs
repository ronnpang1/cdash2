using Inspinia_MVC5.Models;
using Inspinia_MVC5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models.ViewModel;
using System.Web.Security;

namespace Inspinia_MVC5.Controllers
{
    public class UIElementsController : Controller
    {

        public static int meetingId = 0;
        public static string commName = " ";


        public ActionResult Typography()
        {
            return View();
        }

        public ActionResult Icons()
        {
            return View();
        }

        public ActionResult DraggablePanels()
        {
            return View();
        }

        public ActionResult ResizeablePanels()
        {
            return View();
        }

        public ActionResult Buttons()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult TablesPanels()
        {
            return View();
        }

        public ActionResult Tabs()
        {
            return View();
        }
        public ActionResult AgendaAccess(String committeeName, int id)
        {
            meetingId = id;
            commName = committeeName;
            //var model = GetDetailsById(id);
            //return View(model);
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;
            cdashEntities1 _db = new cdashEntities1();

            var model = from meeting in _db.meetings
                        join agenda in _db.agendanotes on meeting.ID equals agenda.meetingId
                        where agenda.Poster == username
                        where agenda.meetingId == meetingId
                        select new agendaviewmodel
                        {

                            notes = agenda.Post,
                            agendaNote = meeting.Message_Agenda,
                            postdate = agenda.Post_date,
                            meetingId= agenda.meetingId

                        };


            return View(model);
        }
        [HttpPost]
        public ActionResult createMeetings(meeting m)
        {

            CreateMeeting newmeeting = new CreateMeeting();

            newmeeting.addmeetingtodb(m);




            return RedirectToAction("Addmeetings", "UIElements");


        }
        [HttpPost]
        public ActionResult submitnotes()
        {

            return View();

        }
        [HttpPost]
        public ActionResult postnotes(agendanote note)
        {

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;
            AgendaNotes newnote = new AgendaNotes();
            newnote.addNote(note, commName, meetingId, username);





            return RedirectToAction("ManageMeetings", "UIElements");
        }


        public ActionResult ManageMeetings()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;

            cdashEntities1 _db = new cdashEntities1();


            var model = from users in _db.users
                        join comlist in _db.committee_Memberlist on users.email equals username
                        join _meeting in _db.meetings on comlist.name_ofCommittee equals _meeting.committee_name
                        select new viewmeeting
                        {

                            committee_name = _meeting.committee_name,
                            Message_Agenda = _meeting.Message_Agenda,
                            meetingid = _meeting.ID,
                            meeting_date = _meeting.end_date,
                            created_date = _meeting.creation_date,
                            active = _meeting.active


                        };






            return View(model);



        }

        public ActionResult Addmeetings()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            string uname = ticket.UserData;


            cdashEntities1 _db = new cdashEntities1();
            addMeetingViewModel m = new addMeetingViewModel();

            //m.committee = (IEnumerable<SelectListItem>)(from c in _db.committee_Memberlist
                       //    where c.Uname_ofMember == uname
                         //  select c.name_ofCommittee).Distinct().ToList();
          


            return View();
        }

        public ActionResult ViewPage1()
        {

            return View();

        }

        public ActionResult NotificationsTooltips()
        {
            return View();
        }

        public ActionResult BadgesLabelsProgress()
        {
            return View();
        }
	}
}