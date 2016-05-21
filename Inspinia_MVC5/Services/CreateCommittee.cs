using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5.Models;

namespace Inspinia_MVC5.Services
{
    public class CreateCommittee
    {
        cdashEntities1 _db = new cdashEntities1();

        public CreateCommittee()
        {

            _db.Database.Connection.Open();

        }


        public void addCommittee(String CommitteeName)
        {


            Committee committee = new Committee
            {

                Committee_Name = CommitteeName,
                Committee_Startdate = DateTime.Now,
                Committee_Enddate = DateTime.Now.AddYears(10),
                Committee_Active = "yes",
                Committee_Faculty = "Supply Chain"

            };
            _db.Committees.Add(committee);
            _db.SaveChanges();
            _db.Dispose();




        }
    }
}