//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspinia_MVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class publications_details
    {
        public int pub_id { get; set; }
        public string username { get; set; }
        public int academic_year { get; set; }
        public Nullable<int> ref_journals { get; set; }
        public Nullable<int> acc_journalarticles { get; set; }
        public Nullable<int> ref_conf_proceedings { get; set; }
        public Nullable<int> Academic_books_monographs { get; set; }
        public Nullable<int> edited_books { get; set; }
        public Nullable<int> chaptors_inbooks { get; set; }
        public Nullable<int> published_reviews { get; set; }
        public Nullable<int> textbooks { get; set; }
        public Nullable<int> other_pub { get; set; }
        public Nullable<int> nonref_journalarticles { get; set; }
    }
}