using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inspinia_MVC5.Models;

namespace Inspinia_MVC5.Services
{
    public class AgendaNotes
    {
        cdashEntities1 _db = new cdashEntities1();
        public AgendaNotes()
        {

            _db.Database.Connection.Open();

        }


        public void addNote(agendanote note, String commName, int meetingId, string username)
        {



            agendanote notes = new agendanote
            {

                Post_date = System.DateTime.Now,
                Poster = username,
                Post = note.Post,
                meetingId = meetingId,
                creation_dateOfCommittee = System.DateTime.Now,
                committee_name = commName


            };
            _db.agendanotes.Add(notes);
            _db.SaveChanges();
            _db.Dispose();




        }
    }
}