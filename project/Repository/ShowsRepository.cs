using project.Factories;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Repository
{
    public class ShowsRepository
    {
        private static Project_DatabaseEntities2 db = new Project_DatabaseEntities2();

        public static bool InsertShow(Show show)
        {
            //Show show = ShowFactory.Create(sellerid, name, price, description);

            if (show != null)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool UpdateShow(Show show)
        {
            if (show != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteShow(int id)
        {
            Show show = db.Shows.Find(id);

            if (show != null)
            {
                db.Shows.Remove(show);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Show> GetShow()
        {
            return (from x in db.Shows select x).ToList();
        }

        public static Show GetShowById(int id)
        {
            return (from x in db.Shows where x.Id.Equals(id) select x).FirstOrDefault();
        }

        public static ShowDetail GetShowDetailById(int showId)
        {
            int Avg_Rating = Convert.ToInt32(GetTotalRatingByReview(showId));

            return (from show in db.Shows
                    join seller in db.Users on show.SellerId equals seller.Id
                    where show.Id == showId
                    select new ShowDetail
                    {
                        Show_Name = show.Name,
                        Seller_Name = seller.Name,
                        Show_Price = show.Price,
                        Description = show.Description,
                        Average_Rating = Avg_Rating,
                    }).FirstOrDefault();
        }



        public static Show GetShowByToken(string token)
        {
            return (from detail in db.TransactionDetails
                    join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                    join show in db.Shows on header.ShowId equals show.Id
                    where detail.Token.Equals(token)
                    select show).FirstOrDefault();
        }

        public static bool CheckShowWithSeller(int showId, int UserId)
        {
            Show queryShow = (from show in db.Shows where show.Id == showId && show.SellerId == UserId select show).FirstOrDefault();

            if (queryShow != null)
            {
                return true;
            }
            return false;
        }

        private static double GetTotalRatingByReview(int showId)
        {
            List<Review> QueryResult = (from review in db.Reviews
                                        join detail in db.TransactionDetails on review.TransactionDetailId equals detail.Id
                                        join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                                        where header.ShowId == showId
                                        select review).ToList();

            int totalLength = QueryResult.Count;

            if (totalLength == 0)
            {
                return 0.0;
            }
            else
            {
                double Avg_Rating = 0;

                foreach (Review review in QueryResult)
                {
                    Avg_Rating += review.Rating;
                }

                return (Avg_Rating / totalLength);
            }
        }
    }
}