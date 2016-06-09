using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{
    public class add_MemberstoCommittee
    {
        cdashEntities1 _db = new cdashEntities1();

        public add_MemberstoCommittee()
        {

            _db.Database.Connection.Open();

        }

        public void add(String username, String CommitteeName)
        {
            System.Diagnostics.Debug.WriteLine("ADDING" + username);
            System.Diagnostics.Debug.WriteLine("length:" + username.Length);

            var newuser = (from users in _db.committee_Memberlist
                           where users.Uname_ofMember == username
                           where users.name_ofCommittee == CommitteeName
                           select users).FirstOrDefault();
;
            System.Diagnostics.Debug.WriteLine("user:" + username + newuser);

            if (newuser != null)
                return;
            else
            {
                System.Diagnostics.Debug.WriteLine("START ADDING" + username);


                committee_Memberlist newmember = new committee_Memberlist
                {

                    name_ofCommittee = CommitteeName,
                    Uname_ofMember = username,
                    member_joindate = System.DateTime.Now,
                    memeber_endate = System.DateTime.Now.AddYears(1),
                    active = "yes"


                };

                _db.committee_Memberlist.Add(newmember);
                try {
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

            

        public void remove(String username, String CommitteeName)
        {
            var user = (from users in _db.committee_Memberlist
                       where users.Uname_ofMember == username
                       where users.name_ofCommittee == CommitteeName
                       select users);

            foreach(var members in user)
            {

                _db.committee_Memberlist.Remove(members);

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