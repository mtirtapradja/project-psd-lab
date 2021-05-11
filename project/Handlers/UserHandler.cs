﻿using project.Factories;
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
    }
}