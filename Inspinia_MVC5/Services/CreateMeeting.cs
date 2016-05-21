using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{
    public class CreateMeeting
    {

        cdashEntities1 _db = new cdashEntities1();

        public CreateMeeting()
        {

            _db.Database.Connection.Open();

        }


        public void addmeetingtodb(meeting m)

        {

            var cname = m.committee_name;
            var message = m.Message_Agenda;
            var endtime = m.end_date;

            meeting newmeeting = new meeting
            {

                committee_name = cname,
                creation_date = DateTime.Now,
                end_date = endtime,
                active = "yes",
                Message_Agenda = message

            };
            _db.meetings.Add(newmeeting);
            _db.SaveChanges();
            _db.Dispose();


        }


    }
}