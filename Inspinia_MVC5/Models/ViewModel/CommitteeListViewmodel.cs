using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class CommitteeListViewmodel
    {
        [Display(Name = "Committee name")]
        public String CommitteeName { get; set; }
        [Display(Name = "Creation date")]
        public DateTime Committee_CreationDate { get; set; }
        [Display(Name = "Number of People")]
        public int? Committee_Numbers { get; set; }
        [Display(Name = "Faculty")]
        public string faculty { get; set; }
        [Display(Name = "Active")]
        public string active { get; set; }
    }
}