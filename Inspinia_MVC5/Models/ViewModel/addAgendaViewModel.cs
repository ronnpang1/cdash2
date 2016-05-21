using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class addAgendaViewModel
    {
        public string note { get; set; }
        public DateTime postdate { get; set; }
        public string author { get; set; }
        public string meetingid { get; set; }
        public string committeename { get; set; }
    }
}