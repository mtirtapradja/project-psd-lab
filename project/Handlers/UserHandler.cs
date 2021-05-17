using project.Factories;
using project.Models;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Handlers
{
    public class UserHandler
    {
        public static bool AddNewUser(string name, string username, string password, int roleId)
        {
            User newUser =  UserFactory.Create(name, username, password, roleId);
            return UserRepository.insertUser(newUser);
        }

        public static bool UpdateCurrentUser(int userId,string name, string newPassword)
        {
            User currentUser = UserRepository.GetUserById(userId);

            if (currentUser != null)
            {
                currentUser.Name = name;
                currentUser.Password = newPassword;
                return UserRepository.updateUser(currentUser);
            }
            return false;
        }

        public static User GetUserById(int userId)
        {
            return UserRepository.GetUserById(userId);
        }

        public static User LoginUser(string username, string password)
        {
            User user = UserRepository.loginUser(username, password);
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