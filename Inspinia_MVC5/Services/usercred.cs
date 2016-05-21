using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{
    public class usercred
    {

        private String username { get; set; }
        private String role { get; set; }


        public String getusername()
        {

            String uname = username;
            return uname;

        }

        public String getRole()
        {

            String Urole = role;
            return Urole;

        }

        public void setuser(String user)
        {

            username = user;

        }

        public void setrole(String urole)
        {

            role = urole;

        }







    }
}