using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public partial class Committee_Details
    {

        public string  Committee_Name{ get; set; }
        public System.DateTime Committee_Startdate { get; set; }
        public System.DateTime Committee_Enddate { get; set; }
        public string Committee_Active { get; set; }
        public ICollection<String> committee_Memberlist { get; set; }
        public int numberofpeople { get; set; }

    }
}