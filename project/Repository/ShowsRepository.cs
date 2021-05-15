using project.Factories;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Repository
{
    public class ShowsRepository
    {
        private static Project_DatabaseEntities2 db = new Project_DatabaseEntities2();

        public static bool InsertShow(Show show)
        {
            //Show show = ShowFactory.Create(sellerid, name, price, description);

            if (show != null)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool UpdateShow(Show show)
        {
            if (show != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteShow(int id)
        {
            Show show = db.Shows.Find(id);

            if (show != null)
            {
                db.Shows.Remove(show);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Show> GetShow()
        {
            return (from x in db.Shows select x).ToList();
        }

        public static Show GetShowById(int id)
        {
            return (from x in db.Shows where x.Id.Equals(id) select x).FirstOrDefault();
        }

    }
}