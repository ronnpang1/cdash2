using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Services
{
    public class pull_pubdetails: DataPull_Interface
    {
        private string datafrom = " ";
        cdashEntities1 _db = new cdashEntities1();
        private string user = " ";
        private string year = " ";


        public pull_pubdetails(String type, string date, string username)
        {
            _db.Database.Connection.Open();
            datafrom = type;
            year = date;
            user = username;
            

        }

       

        public double getAverage()
        {
            double avg = 0;
            int count = getCount();
            int sum = getsum();
            if (count == 0)
                avg = 0;
            else
             avg = sum / count;



            return avg;
           
        }

      

        public int getCount()
        {
           

            
              switch (datafrom)
            {

                case "ref_journals":
                    int entries = (int)(from pubs in _db.publications_details
                                        select pubs.ref_journals).Count();
                    return entries;


                case "acc_jour":
                    int acc_entries = (int)(from pubs in _db.publications_details
                                        select pubs.acc_journalarticles).Count();
                    return acc_entries;


                case "conf_proceed":
                    int conf_proceed = (int)(from pubs in _db.publications_details
                                        select pubs.ref_conf_proceedings).Count();
                    return conf_proceed;

                case "Academic_books_mono":
                    int abm = (int)(from pubs in _db.publications_details
                                     select pubs.Academic_books_monographs).Count();
                    return abm;


                case "edited_books":
                    int edited_books = (int)(from pubs in _db.publications_details
                                              select pubs.edited_books).Count();
                    return edited_books;

                case "chaptors_inbooks":
                    int chaptors_inbooks = (int)(from pubs in _db.publications_details
                                                 select pubs.chaptors_inbooks).Count();
                    return chaptors_inbooks;


                case "pub_review":
                    int pub_review = (int)(from pubs in _db.publications_details
                                          select pubs.published_reviews).Count();
                    return pub_review;

                case "textbook":
                    int textbook = (int)(from pubs in _db.publications_details
                                         select pubs.textbooks).Count();
                    return textbook;

                case "other_pub":
                    int other_pub = (int)(from pubs in _db.publications_details
                                           select pubs.other_pub).Count();
                    return other_pub;


                default: return 0;

            }

            
        }


        public int getEntries()
        {
            switch (datafrom)
            {

                case "ref_journals":
                    int entries = (int)(from pubs in _db.publications_details
                                        where pubs.username == user
                                        select pubs.ref_journals).First();
                    return entries;


                case "acc_jour":
                    int acc_entries = (int)(from pubs in _db.publications_details
                                            where pubs.username == user
                                            select pubs.acc_journalarticles).First();
                    return acc_entries;


                case "conf_proceed":
                    int conf_proceed = (int)(from pubs in _db.publications_details
                                             where pubs.username == user
                                             select pubs.ref_conf_proceedings).First();
                    return conf_proceed;

                case "Academic_books_mono":
                    int abm = (int)(from pubs in _db.publications_details
                                    where pubs.username == user
                                    select pubs.Academic_books_monographs).First();
                    return abm;


                case "edited_books":
                    int edited_books = (int)(from pubs in _db.publications_details
                                             where pubs.username == user
                                             select pubs.edited_books).First();
                    return edited_books;

                case "chaptors_inbooks":
                    int chaptors_inbooks = (int)(from pubs in _db.publications_details
                                                 where pubs.username == user
                                                 select pubs.chaptors_inbooks).First();
                    return chaptors_inbooks;


                case "pub_review":
                    int pub_review = (int)(from pubs in _db.publications_details
                                           where pubs.username == user
                                           select pubs.published_reviews).First();
                    return pub_review;

                case "textbook":
                    int textbook = (int)(from pubs in _db.publications_details
                                         where pubs.username == user
                                         select pubs.textbooks).First();
                    return textbook;

                case "other_pub":
                    int other_pub = (int)(from pubs in _db.publications_details
                                          where pubs.username == user
                                          select pubs.other_pub).First();
                    return other_pub;


                default: return 0;

            }
        }

        public int getsum()
        {

            switch (datafrom)
            {

                case "ref_journals":
                    int entries = (int)(from pubs in _db.publications_details
                                        select pubs.ref_journals).Sum();
                    return entries;


                case "acc_jour":
                    int acc_entries = (int)(from pubs in _db.publications_details
                                            select pubs.acc_journalarticles).Sum();
                    return acc_entries;


                case "conf_proceed":
                    int conf_proceed = (int)(from pubs in _db.publications_details
                                             select pubs.ref_conf_proceedings).Sum();
                    return conf_proceed;

                case "Academic_books_mono":
                    int abm = (int)(from pubs in _db.publications_details
                                    select pubs.Academic_books_monographs).Sum();
                    return abm;


                case "edited_books":
                    int edited_books = (int)(from pubs in _db.publications_details
                                             select pubs.edited_books).Sum();
                    return edited_books;

                case "chaptors_inbooks":
                    int chaptors_inbooks = (int)(from pubs in _db.publications_details
                                                 select pubs.chaptors_inbooks).Sum();
                    return chaptors_inbooks;


                case "pub_review":
                    int pub_review = (int)(from pubs in _db.publications_details
                                           select pubs.published_reviews).Sum();
                    return pub_review;

                case "textbook":
                    int textbook = (int)(from pubs in _db.publications_details
                                         select pubs.textbooks).Sum();
                    return textbook;

                case "other_pub":
                    int other_pub = (int)(from pubs in _db.publications_details
                                          select pubs.other_pub).Sum();
                    return other_pub;


                default: return 0;

            }


        }

    }
}