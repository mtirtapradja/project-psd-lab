using project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Factory
{
    public class ShowFactory
    {
        public static Show Create(int sellerid, string name, int price, string description)
        {
            Show show = new Show();
            show.SellerId = sellerid;
            show.Name = name;
            show.Price = price;
            show.Description = description;
            return show;
        }

    }
}