using project.Factories;
using project.Models;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Handlers
{
    public class ShowHandler
    {

        public static bool InsertNewShow (int sellerid, string name, int price, string description)
        {
            Show newShow = ShowFactory.Create(sellerid, name, price, description);

            return ShowsRepository.InsertShow(newShow);
        }
    }
}