using project.Handlers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace project.Controllers
{
    public class ShowController
    {
        public static string CheckAddShow(int SellerId, string name, string URL, string description, string s_price)
        {
            string response = "";
            Regex expression = new Regex(@"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");

            if (name == "")
            {
                response = "Name must be filled";
            }
            else if (name.Length < 5)
            {
                response = "Name must be at least 5 characters";
            }
            else if (URL == "")
            {
                response = "URL must be filled";
            }
            else if (!expression.IsMatch(URL))
            {
                response = "URL must be valid format";
            }
            else if (description == "")
            {
                response = "Description must be filled";
            }
            else if (s_price == "")
            {
                response = "Price must be filled";
            }
            else if (int.Parse(s_price) < 1000)
            {
                response = "Price must be at least 1000";
            }
            else
            {
                int price = int.Parse(s_price);
                ShowHandler.InsertNewShow(SellerId, name, price, description);
            }

            return response;
        } 
        
        public static string CheckUpdateShow(int SellerId, string name, string URL, string description, string s_price)
        {
            string response = "";
            Regex expression = new Regex(@"[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");

            if (name == "")
            {
                response = "Name must be filled";
            }
            else if (name.Length < 5)
            {
                response = "Name must be at least 5 characters";
            }
            else if (URL == "")
            {
                response = "URL must be filled";
            }
            else if (!expression.IsMatch(URL))
            {
                response = "URL must be valid format";
            }
            else if (description == "")
            {
                response = "Description must be filled";
            }
            else if (s_price == "")
            {
                response = "Price must be filled";
            }
            else if (int.Parse(s_price) < 1000)
            {
                response = "Price must be at least 1000";
            }
            else
            {
                int price = int.Parse(s_price);
                ShowHandler.UpdateShow(SellerId, name, price, description);
            }

            return response;
        }

        public static List<Show> GetAllShow()
        {
            return ShowHandler.GetAllShow();
        }

        public static Show GetShowById(int Id)
        {
            return ShowHandler.GetShowById(Id);
        }
    }
}