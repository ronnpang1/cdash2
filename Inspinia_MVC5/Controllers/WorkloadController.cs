using Inspinia_MVC5.Models;
using Inspinia_MVC5.Models.ViewModel;
using Inspinia_MVC5.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inspinia_MVC5.Controllers
{
    public class WorkloadController : Controller
    {
        cdashEntities1 _db = new cdashEntities1();
        // GET: Workload

        public static string user = " ";
        public ActionResult Index()
        {

            var model = (from memberlist in _db.committee_Memberlist
                         join users in _db.users on memberlist.Uname_ofMember equals users.email

                         select new Loadprofessors()
                         {

                             Name = users.FIRSTName,
                             Lname = users.LASTName,
                             email = users.email,
                             Role = users.role


                         }).Distinct().ToList();

            return View(model);
        }

        // GET: Workload/Details/5
        // id hardcoded or something
        //change the value of the parameter you are passing
        public ActionResult Details(String username)
        {
            var usermodel = (from user in _db.publications_details
                             where user.username == username
                             select new workloadviewmodel
                             {

                                 username = user.username,
                                 academic_year = user.academic_year,
                                 ref_journals = user.ref_journals,
                                 acc_journalarticles = user.acc_journalarticles,
                                 ref_conf_proceedings = user.ref_conf_proceedings,
                                 Academic_books_monographs = user.Academic_books_monographs,
                                 edited_books = user.edited_books,
                                 chaptors_inbooks = user.chaptors_inbooks,
                                 published_reviews = user.published_reviews,
                                 textbooks = user.textbooks,
                                 other_pub = user.other_pub,
                                 nonref_journalarticles = user.nonref_journalarticles

                             }).FirstOrDefault();
            user = username;
            return View(usermodel);
        }


        

        public ActionResult assignworkload()
        {

            var model = from users in _db.users
                        select new Assignlist_Viewmodel
                        {
                            Name = users.FIRSTName,
                            Lname = users.LASTName,
                            email = users.email,
                            Role = users.role

                        };

            return View(model);

        }


        public ActionResult Getstats(String username)
        {

            user = username;
            getbardata();

            return PartialView();
        }
        [HttpPost]
        public ActionResult getdata(String datafrom)
        {
            System.Diagnostics.Debug.WriteLine("username" + user+ "datafrom "+ datafrom);
            pull_pubdetails pub = new pull_pubdetails(datafrom,"2015",user);
            var barstatsmodel = new barstatsviewmodel
            {
                Year = "2015",
                entries = pub.getEntries(),
                avg = pub.getAverage(),
                datasource = datafrom

            };

            var json = JsonConvert.SerializeObject(barstatsmodel);

            return Json(json);
        }

        [HttpPost]
        public ActionResult getbardata()
        {
            double refjournalavg = 0;

            System.Diagnostics.Debug.WriteLine(user);

            int refjournalstats = (int)(from pubs in _db.publications_details
                                        where pubs.username == user
                                        select pubs.ref_journals).First();
            int refjournalstatssum = (int)(from pubs in _db.publications_details
                                           select pubs.ref_journals).Sum();

            int refjournalstatscount = (int)(from pubs in _db.publications_details
                                             select pubs.ref_journals).Count();

            if (refjournalstatscount != 0)
                refjournalavg = (double)refjournalstatssum / refjournalstatscount;


            System.Diagnostics.Debug.WriteLine("sum " + refjournalstatssum + "count " + refjournalstatscount + "entries " + refjournalstats);

            var barstatsmodel = new barstatsviewmodel
            {
                Year = "2015",
                entries = refjournalstats,
                avg = refjournalavg,
                datasource = "ref_journals"


            };
            string json = JsonConvert.SerializeObject(barstatsmodel);
            ViewBag.year = "2015";
            ViewBag.refjournal = refjournalstats;
            ViewBag.journalavg = 2;

            return Json(json);

        }

        // GET: Workload/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workload/Create
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

        // GET: Workload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        public ActionResult getcommittee_list(String username)
            {

            var new_model = (from committee in _db.committee_Memberlist
                            where committee.Uname_ofMember == username
                            select new retrievecommlist
                            {


                                Committeename = committee.name_ofCommittee

                            }).Distinct();




            return PartialView(new_model);
            
            
            
            }

        public ActionResult getcourses_list()
        {





            return PartialView();



        }


        [HttpPost]
        public ActionResult pubdetails_piegraph()
        {

            var usermodel = (from users in _db.publications_details
                             where users.username == user
                             select new workloadviewmodel
                             {

                                 username = users.username,
                                 academic_year = users.academic_year,
                                 ref_journals = users.ref_journals,
                                 acc_journalarticles = users.acc_journalarticles,
                                 ref_conf_proceedings = users.ref_conf_proceedings,
                                 Academic_books_monographs = users.Academic_books_monographs,
                                 edited_books = users.edited_books,
                                 chaptors_inbooks = users.chaptors_inbooks,
                                 published_reviews = users.published_reviews,
                                 textbooks = users.textbooks,
                                 other_pub = users.other_pub,
                                 nonref_journalarticles = users.nonref_journalarticles

                             }).FirstOrDefault();

            string json = JsonConvert.SerializeObject(usermodel);



            return Json(json);

        }


        // POST: Workload/Edit/5
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

        // GET: Workload/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Workload/Delete/5
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
