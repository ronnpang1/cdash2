using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class PersonViewModel
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Role { get; set; }
        public IEnumerable<Committee> committee {get;set;}
    }
}