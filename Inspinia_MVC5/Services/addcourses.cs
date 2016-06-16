using Inspinia_MVC5.Models;
using Inspinia_MVC5.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{
    public class addcourses
    {

        cdashEntities1 _db = new cdashEntities1();

        public addcourses()
        {
            _db.Database.Connection.Open();

        }

        public void putcourse(String CourseName, int coursenumber)

        {


            courseslist course = new courseslist
            {

                courseName = CourseName,
                courseNumber = coursenumber

            };

            _db.courseslists.Add(course);
            _db.SaveChanges();
            _db.Dispose();


        }

        public void coursepreqadd(courseAdd_Viewmodel ca)
        {
            var newmodel = new coursepreq
            {

                courseName = ca.coursename,
                courseNumber = ca.coursenum,
                course_preqforName = ca.coursenameprereq_for,
                course_preqforNumb = ca.coursenumprereq_for,
                course_preqforid = (from courses in _db.courseslists
                            where courses.courseName == ca.coursenameprereq_for
                            where courses.courseNumber == ca.coursenumprereq_for
                            select courses.courseID).FirstOrDefault(),
                course_group=ca.coursegroup,
                course_case= ca.course_case


            };

            _db.coursepreqs.Add(newmodel);
            _db.SaveChanges();
            _db.Dispose();


        }

        public void coursepreqadd(String coursename, int coursenumber, String coursenamepreqfor, int coursenumberpreqfor,int group,int coursecase)
        {
            var newmodel = new coursepreq
            {

                courseName = coursenamepreqfor,
                courseNumber = coursenumberpreqfor,
                course_preqforName = coursename,
                course_preqforNumb = coursenumber,
                course_preqforid = (from courses in _db.courseslists
                                    where courses.courseName == coursename
                                    where courses.courseNumber == coursenumber
                                    select courses.courseID).FirstOrDefault(),
                course_group = group,
                course_case = coursecase


            };

            _db.coursepreqs.Add(newmodel);
            _db.SaveChanges();
            _db.Dispose();


        }
    }
}