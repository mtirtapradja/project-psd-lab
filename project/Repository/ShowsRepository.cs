﻿using project.Factories;
using project.Models;

namespace project.Repository
{
    public class ShowsRepository
    {
        private static Project_DatabaseEntities db = new Project_DatabaseEntities();

        public static bool InsertShow(int sellerid, string name, int price, string description)
        {
            Show show = ShowFactory.Create(sellerid, name, price, description);

            if (show != null)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool UpdateShow(int id, int sellerid, string name, int price, string description)
        {
            Show show = db.Shows.Find(id);

            if (show != null)
            {
                show.SellerId = sellerid;
                show.Name = name;
                show.Price = price;
                show.Description = description;
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
    }
}