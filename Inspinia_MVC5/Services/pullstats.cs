using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{

    public class pullstats
    {
        private string datafrom = " ";
        cdashEntities1 _db = new cdashEntities1();

        public pullstats(String type)
        {
            _db.Database.Connection.Open();
            datafrom = type;

        }


        public int getEntries(String user,string year)
        {

            switch (datafrom)
            {

                case "pub":
                  int entries=  (int)(from pubs in _db.publications_details
                          where pubs.username == user
                          select pubs.ref_journals).First();
                    return entries;


                //case "rsh":
                //    int entries = (int)(from pubs in _db.research_grants
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;

                //case "conf_presentations":
                //    int entries = (int)(from pubs in _db.conf_presentations
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;

                //case "rsh_supervision":
                //    int entries = (int)(from pubs in _db.rsh_supervision
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;



                //case "rsh_supervision":
                //    int entries = (int)(from pubs in _db.rsh_supervision
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;

                default: return 0;

            }

           



            
        }


        public double getAvg(String user,string year)
        {

            switch (datafrom)
            {

                case "pub":
                    double refjournalavg = 0;

                    int refjournalstats = (int)(from pubs in _db.publications_details
                                                where pubs.username == user
                                                select pubs.ref_journals).First();
                    int refjournalstatssum = (int)(from pubs in _db.publications_details
                                                   select pubs.ref_journals).Sum();

                    int refjournalstatscount = (int)(from pubs in _db.publications_details
                                                     select pubs.ref_journals).Count();

                    if (refjournalstatscount != 0)
                        refjournalavg = (double)refjournalstatssum / refjournalstatscount;




                    return refjournalavg;


                //case "rsh":
                //    int entries = (int)(from pubs in _db.research_grants
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;

                //case "conf_presentations":
                //    int entries = (int)(from pubs in _db.conf_presentations
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;

                //case "rsh_supervision":
                //    int entries = (int)(from pubs in _db.rsh_supervision
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;



                //case "rsh_supervision":
                //    int entries = (int)(from pubs in _db.rsh_supervision
                //                        where pubs.username == user
                //                        select pubs.ref_journals).First();
                //    break;

                default: return 0;

            }






        }

    }
}