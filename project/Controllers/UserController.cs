using project.Handlers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace project.Controllers
{
    public class UserController
    {
        public static User GetUserById(int userId)
        {
            return UserHandler.GetUserById(userId);
        }

        public static string CheckRegister(string name, string username, string password, string confirmPassword)
        {
            string response = "";
            Regex expressionName = new Regex("^[a-zA-Z\\s]*$");
            Regex expressionUserName = new Regex("^[a-zA-Z0-9_\\s]*$");
            Regex expressionPassword = new Regex("^[a-zA-Z0-9]*$");

            if (name == "")
            {
                response = "Name must be filled";
            }
            else if (name.Length < 0 || name.Length > 30)
            {
                response = "Name must not exceed 30 characters";
            }
            else if (!expressionName.IsMatch(name))
            {
                response = "Name must contain space";
            }
            else if (username == "")
            {
                response = "Username must be filled";
            }
            else if (username.Length < 6 || username.Length > 20)
            {
                response = "Username must be between 6 and 20 characters";
            }
            else if (!expressionUserName.IsMatch(username))
            {
                response = "Username must contain space or underscore"; 
            }
            else if (password == "")
            {
                response = "Password must be filled";
            }
            else if (password.Length < 6)
            {
                response = "Password must be more than 6 characters";
            }
            else if (!expressionPassword.IsMatch(password))
            {
                response = "Password format invalid";
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

        public static string CheckLogin(string username, string password)
        {
            string response = "";

            if (username == "")
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
            else
            {
                User user = GetUserByUsernameAndPassword(username, password);

                if (user == null)
                {
                    response = "User not found, Please input username and passsword correctly";
                }
            }

            return response;
        }

        public static string CheckUpdate(int userId, string name, string oldPassword, string newPassword, string confirmPassword)
        {
            string response = "";
            Regex expression = new Regex("^[a-zA-Z0-9]*$");
            User currentUser = UserHandler.GetUserById(userId);

            if(name == "")
            {
                response = "Name must be filled";
            }
            else if(name.Length<1 || name.Length > 30)
            {
                response = "Name must be between 1 dan 30 characters";
            }
            else if(oldPassword == "")
            {
                response = "Old password must be filled";
            }
            else if (!currentUser.Password.Equals(oldPassword))
            {
                response = "Old password does not match";
            }
            else if(newPassword == "")
            {
                response = "New password must be filled";
            }
            else if (newPassword.Length<6)
            {
                response = "New password must at least 6 characters";
            }
            else if (!expression.IsMatch(newPassword))
            {
                response = "New Password format invalid";
            }
            else if (confirmPassword == "")
            {
                response = "Confirm password must be filled";
            }
            else if (!confirmPassword.Equals(newPassword))
            {
                response = "Password confirmation not match";
            }
            return response;
        }

        public static User Login(string username, string password)
        {
            User user = UserHandler.LoginUser(username, password);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        private static User GetUserByUsernameAndPassword(string username, string password)
        {
            return UserHandler.GetUserByUsernameAndPassword(username, password);
        }

        public static bool UpdateCurrentUser(int userId, string name, string password)
        {
            return UserHandler.UpdateCurrentUser(userId, name, password);
        }

        public static User CheckUserName(int userId)
        {
            return UserHandler.GetUserById(userId);
        }
    }
}