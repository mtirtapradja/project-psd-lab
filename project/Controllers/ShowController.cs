using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace project.Controllers
{
    public class ShowController
    {
        public static string CheckAddShow(string name, string URL, string description, string price)
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
            else if (price == "")
            {
                response = "Price must be filled";
            }
            else if (int.Parse(price) < 1000)
            {
                response = "Price must be at least 1000";
            }

            return response;
        }
    }
}