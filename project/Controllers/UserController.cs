using project.Handlers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Controllers
{
    public class UserController
    {
        public static string CheckRegister(string name, string username, string password, string confirmPassword)
        {
            string response = "";

            if (name == "")
            {
                response = "Name must be filled";
            }
            else if (name.Length < 0 || name.Length > 30)
            {
                response = "Name must not exceed 30 characters";
            }
            else if (username == "")
            {
                response = "Username must be filled";
            }
            else if (username.Length < 6 || username.Length > 30)
            {
                response = "Username must be between 6 and 30 characters";
            }
            else if (password == "")
            {
                response = "Password must be filled";
            }
            else if (password.Length < 6)
            {
                response = "Password must be more than 6 characters";
            }
            else if (confirmPassword == "")
            {
                response = "Password confirmation must be filled";
            }
            else if (!confirmPassword.Equals(password))
            {
                response = "Password confirmation not match";
            }

            return response;
        }

        public static bool AddNewUser(string name, string username, string password, int roleId)
        {
            return UserHandler.AddNewUser(name, username, password, roleId);
        }
    }
}