using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{

    public class getpreq
    {
        cdashEntities1 _db = new cdashEntities1();


        public getpreq()
        {

            _db.Database.Connection.Open();


        }


        public String preq_course(String coursename)
        {


            return coursename;

        }


        public String copreq_course(String coursename)
        {


            return coursename;

        }

    }
}