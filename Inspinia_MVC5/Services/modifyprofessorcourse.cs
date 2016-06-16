using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{
    public class modifyprofessorcourse
    {
        cdashEntities1 _db = new cdashEntities1();

        public modifyprofessorcourse()
        {

            _db.Database.Connection.Open();

        }

        public void add(String username, String CourseName,int CourseNum)
        {
            System.Diagnostics.Debug.WriteLine("ADDING" + username);
            System.Diagnostics.Debug.WriteLine("length:" + username.Length);

            var newuser = (from users in _db.courses_memberlist
                           where users.instructor == username
                           where users.CourseName == CourseName
                           where users.CourseNum == CourseNum
                           select users).FirstOrDefault();
            
            System.Diagnostics.Debug.WriteLine("user:" + username + newuser);

            if (newuser != null)
                return;
            else
            {
                System.Diagnostics.Debug.WriteLine("START ADDING" + username);


                courses_memberlist newmember = new courses_memberlist
                {

                    CourseName = CourseName,
                    CourseNum = CourseNum,
                    instructor = username,
                    add_date = System.DateTime.Now,
                    end_date = System.DateTime.Now.AddYears(1),
                    active = "yes"


                };

                _db.courses_memberlist.Add(newmember);
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
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }



            }
        }



        public void remove(string email, string coursename, int coursenumber)
        {
            var newuser = (from users in _db.courses_memberlist
                           where users.instructor == email
                           where users.CourseName == coursename
                           where users.CourseNum == coursenumber
                           select users);

            foreach (var members in newuser)
            {

                _db.courses_memberlist.Remove(members);

            }


            try
            {

                _db.SaveChanges();




            }
            catch (Exception)
            {

            }

        }
        public void dispose()
        {

            _db.Dispose();

        }

       
    }
}