using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class courseAdd_Viewmodel
    {
        [Display(Name = "Course name")]
        public String coursename { get; set; }

        [Display(Name = "Course num")]
        public int coursenum { get; set; }

        [Display(Name = "Course name preq for")]
        public String coursenameprereq_for { get; set; }

        [Display(Name = "Course num preq for")]
        public int coursenumprereq_for { get; set; }

        [Display(Name = "Course id preq for")]
        public int courseidpreqfor { get; set; }

        [Display(Name = "Course group number")]
        public int coursegroup { get; set; }

        [Display(Name = "Course case")]
        public int course_case{get;set;}
    }
}