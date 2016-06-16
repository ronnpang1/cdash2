using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class workloadviewmodel
    {

        [Display(Name = "User")]
        public string username { get; set; }
        [Display(Name = "Year")]
        public int academic_year { get; set; }
        [Display(Name = "Referred Journals")]
        public Nullable<int> ref_journals { get; set; }
        [Display(Name = "Accepted Journal Entries")]
        public Nullable<int> acc_journalarticles { get; set; }
        [Display(Name = "Reffered Journal Entries")]
        public Nullable<int> ref_conf_proceedings { get; set; }
        [Display(Name = "Academic Books and monographs")]
        public Nullable<int> Academic_books_monographs { get; set; }
        [Display(Name = "Edited Books")]
        public Nullable<int> edited_books { get; set; }
        [Display(Name = "Books Chapters")]
        public Nullable<int> chaptors_inbooks { get; set; }
        [Display(Name = "Published Reviews")]
        public Nullable<int> published_reviews { get; set; }
        [Display(Name = "Textbooks")]
        public Nullable<int> textbooks { get; set; }
        [Display(Name = "Other Pubs")]
        public Nullable<int> other_pub { get; set; }
        [Display(Name = "Non-Reffered Articles")]
        public Nullable<int> nonref_journalarticles { get; set; }


    }
}