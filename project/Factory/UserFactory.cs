using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Model;

namespace project.Factory
{
    public class UserFactory
    {
        public static User Create(string username, string password, string name, int role)
        {
            User u = new User();
            u.Username = username;
            u.Password = password;
            u.Name = name;
            u.Role = role;
            return u;
        }
    }
}