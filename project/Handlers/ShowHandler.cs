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
        
        public static bool UpdateShow (int id, string name, int price, string description)
        {
            Show currentShow = ShowsRepository.GetShowById(id);

            if (currentShow != null)
            {
                currentShow.Name = name;
                currentShow.Price = price;
                currentShow.Description = description;

                return ShowsRepository.UpdateShow(currentShow);
            }

            return false;
        }
        

        public static List<Show> GetShowBySellerId(int sellerId)
        {
            return ShowsRepository.GetShowBySellerId(sellerId);
        }

        public static List<Show> GetAllShow()
        {
            return ShowsRepository.GetShow();
        }

        public static Show GetShowById(int id)
        {
            return ShowsRepository.GetShowById(id);
        }

        public static ShowDetail GetShowDetailById(int showId)
        {
            return ShowsRepository.GetShowDetailById(showId);
        }


        public static Show GetShowByToken(string token)
        {
            return ShowsRepository.GetShowByToken(token);
        }

        public static bool CheckShowWithSeller(int showId, int UserId)
        {
            return ShowsRepository.CheckShowWithSeller(showId, UserId);
        }

        public static bool DeleteShow(int id)
        {
            return ShowsRepository.DeleteShow(id);
        }

    }
}