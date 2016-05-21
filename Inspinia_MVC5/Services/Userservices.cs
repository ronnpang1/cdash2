using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5.Models;
using System.Web.Security;
using System.Web.Helpers;

namespace Inspinia_MVC5.Services
{
    public class Userservices
    {
        private cdashEntities1 _db = new cdashEntities1();

        public Userservices()
        {
            _db.Database.Connection.Open();
        }

        
        public void CreateAccount(user s)
        {

            var hashedpassword = Crypto.HashPassword(s.password);
                    var user = new user
                    {

                        FIRSTName = s.FIRSTName.ToString(),
                        LASTName = s.LASTName.ToString(),
                        email = s.email.ToString(),
                        password = hashedpassword.ToString(),
                        role = s.role.ToString()
                    };

                    _db.users.Add(user);
                    try
                   {
                        _db.SaveChanges();
                   }
        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        {
    Exception raise = dbEx;
    foreach (var validationErrors in dbEx.EntityValidationErrors)
    {
        foreach (var validationError in validationErrors.ValidationErrors)
        {
            string message = string.Format("{0}:{1}", 
                validationErrors.Entry.Entity.ToString(),
                validationError.ErrorMessage);
            // raise a new exception nesting
            // the current instance as InnerException
            raise = new InvalidOperationException(message, raise);
              }
             }
            throw raise;
             }
                    _db.Dispose();         
            }
        
        public Boolean ValidateUser(String s,String p)
        {
            var username = s.ToString();

            var getpw = (from u in _db.users where u.email == username
                                                select u.password
                                                ).FirstOrDefault();


            if (getpw != null && Checkpassword(getpw, p))
            {
                return true;
            }
            else
            return false;

        }


        

        public Boolean Checkpassword(String Hpw, String pw)
        {


            var pwmatch = Crypto.VerifyHashedPassword(Hpw,pw);
            return pwmatch;

        }

        public Boolean userexist(user s)
        {

            var useremail = s.email.ToString();
                var user = _db.users.Where(e => e.email == useremail).FirstOrDefault();

                if (user != null)

                    return true;
                else
                    return false;
            }

        }


    }

