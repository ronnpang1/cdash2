using Inspinia_MVC5.Models;
using Inspinia_MVC5.Models.ViewModel;
using Inspinia_MVC5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inspinia_MVC5.Controllers
{
    public class TablesController : Controller
    {
        public static string coursename = " ";
        public static int coursenumber = 0;
        cdashEntities1 _db = new cdashEntities1();
        public Boolean isEmpty = true;
        

        public ActionResult StaticTables()

        {
            return View();
        }
        [HttpPost]
        public ActionResult registercourse(courseslist course)
        {

            addcourses newcourse = new addcourses();
            newcourse.putcourse(course.courseName, course.courseNumber);
            return RedirectToAction("ManageCourses", "Tables");
        }
        public ActionResult loadcourseprofessors()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var username = ticket.UserData;
            //var query = (from profs in _db.courses_memberlist
            //             where username == profs.instructor
            //             where profs.CourseName == coursename
            //             where profs.CourseNum == coursenumber
            //             select profs.instructor).FirstOrDefault();

            var model = from users in _db.users
                        select new loadcourseprofessors()
                        {

                            Name = users.FIRSTName,
                            Lname = users.LASTName,
                            email = users.email,
                            Role = users.role,
                            Assigned = (from profs in _db.courses_memberlist
                                        where profs.instructor == users.email
                                        where profs.CourseName == coursename
                                        where profs.CourseNum == coursenumber
                                        select profs.instructor).Any() ? true:false
                        };

            var model2 = (from users in model
                          orderby users.Assigned
                          select users).ToList();

            return PartialView(model2);

        }
        [HttpPost]
        public ActionResult CourseAddMethod(courseAdd_Viewmodel ca)
        {

            addcourses cpreq = new addcourses();
            cpreq.coursepreqadd(coursename,coursenumber,ca.coursename,ca.coursenum, ca.coursegroup, ca.course_case);

            return RedirectToAction("addpreqcourses", "Tables", new { courseName = coursename, courseid = coursenumber });

        }

        public ActionResult CourseAddMethod1(String C_name,int c_number)
        {

            addcourses cpreq = new addcourses();

            return View();
        }


        public ActionResult addpreqcourses(String courseName, String courseId)
        {

            coursename = courseName;
            coursenumber = Convert.ToInt32(courseId);

            return View();
        }

        public ActionResult listpreqs(String courseName, String courseId)
        {
            coursename = courseName;
            coursenumber = Int32.Parse(courseId);

            var model = (from users in _db.coursepreqs
                         where users.course_preqforName == coursename
                         where users.course_preqforNumb == coursenumber
                         select users).Count();
            System.Diagnostics.Debug.WriteLine(model);

            if (model > 0)
            {
                ViewBag.empty = "false";
            }

            else
            {
                ViewBag.empty = "true";
            }

            var test = ViewBag.empty;

            //System.Diagnostics.Debug.WriteLine("BOOL VAL"+ test);


            return View();
        }

        [HttpPost]
        public ActionResult EditMembers2(IEnumerable<loadcourseprofessors> lc)
        {
            modifyprofessorcourse newmember = new modifyprofessorcourse();
            if (lc != null)
            {
                System.Diagnostics.Debug.WriteLine("from3");
                foreach (var member in lc)
                {
                    System.Diagnostics.Debug.WriteLine("memberassigned:" + member.email + " " + member.Assigned);
                    if (member.Assigned == true)
                    {



                        newmember.add(member.email, coursename,coursenumber);

                    }

                    else
                        newmember.remove(member.email, coursename, coursenumber);

                }
                newmember.dispose();
                return Json("Table Updated");
            }

            else
            {
                return Json("An Error Has occoured");
            }


        }


        public ActionResult ManageCourses()
        {
            cdashEntities1 _db = new cdashEntities1();

            var model = from courses in _db.courseslists
                        select new viewcourses()
                        {
                            courseName = courses.courseName,
                            courseNumber = courses.courseNumber



                        };

            return View(model);
        }

        public ActionResult getorcoursepreqs()
        {
            System.Diagnostics.Debug.WriteLine("from4"+ coursename);
            System.Diagnostics.Debug.WriteLine("from4" + coursenumber);

            var nmodel = (from c in _db.coursepreqs
                          where c.course_preqforName == coursename
                          where c.course_preqforNumb == coursenumber
                          where c.course_case == 1

                          select new coursepreqclass
                          {

                              CourseName = c.courseName,
                              CourseNumber = c.courseNumber.ToString()


                          });

            if (nmodel != null)
            {


                isEmpty = false;

            }

            return PartialView(nmodel);



        }

        public ActionResult getprevorconcpreqs()
        {

            var nmodel = (from c in _db.coursepreqs
                          where c.course_preqforName == coursename
                          where c.course_preqforNumb == coursenumber
                          where c.course_case == 3


                          select new coursepreqclass
                          {

                              CourseName = c.courseName,
                              CourseNumber = c.courseNumber.ToString()


                          });

            if (nmodel != null)
            {


                isEmpty = false;

            }


            return PartialView(nmodel);
        }

        public ActionResult getcoursepreqs()
        {



            var nmodel = (from c in _db.coursepreqs
                          where c.course_preqforName == coursename
                          where c.course_preqforNumb == coursenumber
                          where c.course_case == 2

                         select new coursepreqclass
                         {

                             CourseName = c.courseName,
                             CourseNumber = c.courseNumber.ToString()


                         });

            if (nmodel != null)
            {


                isEmpty = false;

            }


            return PartialView(nmodel);


        }

        public ActionResult Orders(String courseName, String courseId)
        {

            coursename = courseName;
            coursenumber = Int32.Parse(courseId);
            return View();
        }

        public ActionResult EditCourse(String courseName,String courseId)
        {

            return RedirectToAction("Orders", "Tables");

        }

        public ActionResult DataTables()
        {
            return View();
        }

        public ActionResult FooTables()
        {
            return View();
        }

        public ActionResult jqGrid()
        {
            return View();
        }
	}
}