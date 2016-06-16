using Inspinia_MVC5.Models;
using Inspinia_MVC5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models.ViewModel;
using System.Web.Security;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net.Http;

namespace Inspinia_MVC5.Controllers
{
    public class UIElementsController : Controller
    {
        cdashEntities1 _db = new cdashEntities1();

        public static int meetingId = 0;
        public static string commName = " ";
        public static String committeeName=" ";

        [HttpPost]
        public ActionResult Editmember(loadcourseprofessors lc)
        {

            if(ModelState.IsValid)
            {


                var newmodel = new committee_Memberlist
                {
                    Uname_ofMember = lc.email,
                    name_ofCommittee = commName,
                    member_joindate = System.DateTime.Now,
                    memeber_endate = System.DateTime.Now.AddYears(1),
                    active = "yes"

                };

                _db.committee_Memberlist.Add(newmodel);
               


            }

            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }

            return Content("success");
        }
        public ActionResult listcom_Members()
        {
            var newmodel = from users in _db.committee_Memberlist
                           where users.name_ofCommittee == commName
                           select users;
            




            return PartialView(newmodel);


        }


        [HttpPost]
        public ActionResult EditMembers1(IEnumerable<loadcourseprofessors> lc)
        {
            if (lc != null)
            {
                System.Diagnostics.Debug.WriteLine( "from3"+commName);
                add_MemberstoCommittee newmember = new add_MemberstoCommittee();
                foreach (var member in lc)
                {
                    System.Diagnostics.Debug.WriteLine("memberassigned:" + member.email + " " + member.Assigned);
                    if (member.Assigned == true)
                    {



                        newmember.add(member.email, commName);

                    }

                    else
                        newmember.remove(member.email, commName);
                   
                }
                newmember.dispose();
                return Json("Table Updated");
            }

            else
            {
                return Json("An Error Has occoured");
            }


        }

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

        public ActionResult Com_profile()
        {
            var commName2 = Request.QueryString["committeeName"].ToString();
            System.Diagnostics.Debug.WriteLine(commName2 + "from2");

            commName = commName2;
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

        public ActionResult AssignNew()
        {


            return View();

        }
        public ActionResult ComDetails()
        {

            var committeename = Request.QueryString["committeeName"].ToString();
            commName = committeename;
            //System.Diagnostics.Debug.WriteLine(committeename);
            var model = from committee in _db.Committees
                        where committee.Committee_Name == committeename
                        select new CommitteeListViewmodel
                        {
                            CommitteeName = committee.Committee_Name,
                            Committee_CreationDate = committee.Committee_Startdate,
                            Committee_Numbers = committee.numberofpeople,
                            faculty = committee.Committee_Faculty,
                            active = committee.Committee_Active



                        };
            return View(model);

        }

      

        public ActionResult ManageCommittees()
        {
            var model = (from committees in _db.Committees
                        select new CommitteeListViewmodel()
                        {
                            CommitteeName = committees.Committee_Name,
                            Committee_CreationDate = committees.Committee_Startdate,
                            Committee_Numbers = committees.numberofpeople,
                            faculty = committees.Committee_Faculty,
                            active = committees.Committee_Active


                        }).Distinct().ToList();


            return View(model);

        }

        public ActionResult prof_view()
        {







            return View();

        }

       


        public ActionResult LoadCommitteeproffessors()
        {
          var committeename =  Request.QueryString["committeeName"];
            commName = committeename;
            cdashEntities1 _db = new cdashEntities1();
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            System.Diagnostics.Debug.WriteLine(committeename+"from loadcommittee");

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;
            var role = "proffessor";

            var model2 = from users in _db.users
                         select new loadcourseprofessors
                         {
                             Name = users.FIRSTName,
                             Lname = users.LASTName,
                             email = users.email,
                             Role = users.role,
                             Assigned = (from profs in _db.committee_Memberlist
                                         where profs.Uname_ofMember == users.email
                                         where profs.name_ofCommittee == committeename
                            select profs.Uname_ofMember).Any() ? true :false


                         };



            var model3 = (from users in model2
                          orderby users.Assigned
                          select users).ToList();

            var model = (from memberlist in _db.committee_Memberlist
                        where memberlist.name_ofCommittee == committeename
                        join users in _db.users on  memberlist.Uname_ofMember equals users.email

                        select new Loadprofessors()
                        {

                            Name = users.FIRSTName,
                            Lname = users.LASTName,
                            email = users.email,
                            Role = users.role


                        }).Distinct().ToList();
            return PartialView(model3);

        }

        [HttpPost]
        public ActionResult getvalues(loadcourseprofessors lc)
        {

            
           System.Diagnostics.Debug.WriteLine("ans" + lc.email);


            var newmodel = new committee_Memberlist
                {
                    Uname_ofMember = lc.email,
                    name_ofCommittee = commName,
                    member_joindate = System.DateTime.Now,
                    memeber_endate = System.DateTime.Now.AddYears(1),
                    active = "yes"

                };
            System.Diagnostics.Debug.WriteLine("email" + newmodel.Uname_ofMember);

            _db.committee_Memberlist.Add(newmodel);
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }






            return RedirectToAction("Addmeetings", "UIElements");


        }



        public ActionResult Loadproffessors()
        {
            var committeename = Request.QueryString["committeeName"];
            commName = committeename;
            System.Diagnostics.Debug.WriteLine(committeename);
            cdashEntities1 _db = new cdashEntities1();
            var role = "proffessor";


            var peoplealreadyincomm = (from memberlist in _db.committee_Memberlist
                                       where memberlist.name_ofCommittee == committeename
                                       select memberlist);


                          //var model2 = (from ppl in peoplealreadyincomm
                          //              where !(from memberlist in _db.committee_Memberlist select memberlist.Uname_ofMember). Contains(ppl.Uname_ofMember)
                          //              join users in _db.users on memberlist.Uname_ofMember equals users.email

            var allprofs = (from memberlist in _db.committee_Memberlist
                             join users in _db.users on memberlist.Uname_ofMember equals users.email

                            select new Loadprofessors()
                        {

                            Name = users.FIRSTName,
                            Lname = users.LASTName,
                            email = users.email,
                            Role = users.role


                        }).Distinct().ToList();
            return PartialView(allprofs);

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
        public ActionResult viewAgenda()
        {

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;
            cdashEntities1 _db = new cdashEntities1();

            var messageModel = from meetings in _db.meetings
                               where meetings.committee_name == commName
                               select new ViewAgendaMessageModel
                               {
                                   Message_Agenda = meetings.Message_Agenda,
                                   Post_date = meetings.creation_date


                               };

            return PartialView(messageModel);

        }
        
        public ActionResult unassign(String email)

        {
            //var committeename = Request.QueryString["committeeName"];
            System.Diagnostics.Debug.WriteLine("from unassign"+ commName);
            var userdeleted = (from users in _db.committee_Memberlist
                           where users.Uname_ofMember == email
                           where users.name_ofCommittee == commName
                               select users);


            if (userdeleted != null)
            {
                foreach(var users in userdeleted) {
                    _db.committee_Memberlist.Remove(users);
                }
            }

            var model2 = (from prof in _db.committee_Memberlist
                          join users in _db.users on prof.Uname_ofMember equals users.email
                          select new loadcourseprofessors
                          {


                              Name = users.FIRSTName,
                              Lname = users.LASTName,
                              email = users.email,
                              Role = users.role,
                              Assigned = (from profs in _db.committee_Memberlist
                                          where profs.Uname_ofMember == users.email
                                          where profs.name_ofCommittee == commName
                                          select profs.Uname_ofMember).Any() ? true : false


                          }).Distinct().ToList();


            try
            {

                _db.SaveChanges();
                _db.Dispose();


            }
            catch (Exception)
            {

            }



            return PartialView("LoadCommitteeproffessors",model2);

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

        public ActionResult ManageCom(String committeeName)
        {

            return PartialView();


        }
        [HttpPost]
        public ActionResult postnotes(agendanote note)
        {

            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;
            AgendaNotes newnote = new AgendaNotes();
            newnote.addNote(note, commName, meetingId, username);





            return RedirectToAction("AgendaAccess", "UIElements", new {committeeName = commName,id = meetingId });
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