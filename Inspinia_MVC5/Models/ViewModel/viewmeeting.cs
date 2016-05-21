using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class viewmeeting
    {

        public int ID { get; set; }
        public string committee_name { get; set; }
        public string Message_Agenda { get; set; }
        public int meetingid { get; set; }
        public System.DateTime meeting_date { get; set; }
        public System.DateTime created_date { get; set; }

        public string active { get; set; }



    }
}