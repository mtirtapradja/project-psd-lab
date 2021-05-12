using project.Factories;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Repository
{
    public class UserRepository
    {
        private static Project_DatabaseEntities db = new Project_DatabaseEntities();

        public static bool insertUser(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        public static User loginUser(string username, string password)
        {
            User user = (from x in db.Users
                                where x.Username.Equals(username) &&
             x.Password.Equals(password)
                                select x)
                                .FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }  
        }
    }
}