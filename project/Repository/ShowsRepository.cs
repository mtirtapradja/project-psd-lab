﻿using project.Factories;
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
            return (from detail in db.TransactionDetails
                    join review in db.Reviews on detail.Id equals review.TransactionDetailId
                    join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                    join show in db.Shows on header.ShowId equals show.Id
                    join seller in db.Users on show.SellerId equals seller.Id
                    where show.Id == showId
                    select new ShowDetail
                    {
                        Show_Name = show.Name,
                        Seller_Name = seller.Name,
                        Description = show.Description,
                        Average_Rating = GetTotalRatingByReview(show.Id),
                        All_Review = GetReviewById(show.Id)
                    }).FirstOrDefault();
        }

        public static List<Review> GetShowReviewById(int showId)
        {
            return (from review in db.Reviews
                    join detail in db.TransactionDetails on review.TransactionDetailId equals detail.Id
                    join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                    join show in db.Shows on header.Id equals show.Id
                    where show.Id == showId
                    select review).ToList();
        }


        private static int GetTotalRatingByReview(int showId)
        {
            return Convert.ToInt32((from review in db.Reviews
                                    join detail in db.TransactionDetails on review.TransactionDetailId equals detail.Id
                                    join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                                    join show in db.Shows on header.ShowId equals show.Id
                                    where show.Id == showId
                                    select review.Rating).Average());
        }
        private static List<Review> GetReviewById(int showId)
        {
            return (from review in db.Reviews where review.TransactionDetailId == showId select review).ToList();
        }

    }
}