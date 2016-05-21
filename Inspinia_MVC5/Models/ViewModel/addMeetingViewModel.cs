using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class addMeetingViewModel
    {
        public String Committee_Name { get; set; }
        public System.DateTime meetingdate { get; set; }
        public System.DateTime creationdate { get; set; }
        public string active { get; set; }


        public IEnumerable<SelectListItem> committee { get; set; }


    }
}