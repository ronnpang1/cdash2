using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Inspinia_MVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Landing", action = "Index", id = "" }
            );

            routes.MapRoute(
            name: "Agenda",
            url: "{UIElements}/{AgendaAccess}/{committee}/{id}",
            defaults: new
            {
             controller = "UIElements",
             action = "AgendaAccess",
             committee = UrlParameter.Optional,
             id = UrlParameter.Optional
            }
         
        );

            routes.MapRoute(
           name: "Course",
           url: "{Tables}/{EditCourse}/{Coursename}/{Coursenumber}",
           defaults: new
           {
               controller = "Tables",
               action = "EditCourse",
               Coursename = UrlParameter.Optional,
               Coursenumber = UrlParameter.Optional
           }

       );


            routes.MapRoute(
          "Workload",
          "{Workload}/{Details}/{username}",
            new
            {
                controller = "Workload",
                action = "Details",
                username = UrlParameter.Optional

            }

       );

            routes.MapRoute(
         name: "remove",
         url: "{UIElements}/{unassign}/{email}",
         defaults: new
         {
             controller = "UIElements",
             action = "unassign",
             email = UrlParameter.Optional,
          
         }

     );

        }

    }
}
