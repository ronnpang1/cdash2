using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models.ViewModel
{
    public class coursepreqsviewmodel
    {
        public coursepreqsviewmodel()

        {

            course = new List<coursepreqclass>();

        }


        public List<coursepreqclass> course { get; set; }
        public string coursenamefor { get; set; }
        public string coursenumberfor { get; set; }

    }
}