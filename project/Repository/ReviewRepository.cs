using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;

namespace project.Repository
{
    public class ReviewRepository
    {
        public static Project_DatabaseEntities2 db = new Project_DatabaseEntities2();

        public static bool InsertNewReview(Review currentReview)
        {
            if (currentReview != null)
            {
                db.Reviews.Add(currentReview);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool UpdateReview(Review currentReview)
        {
            if (currentReview != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteReview(Review currentReview)
        {
            if (currentReview!=null)
            {
                db.Reviews.Remove(currentReview);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static Review GetReviewById(int reviewId)
        {
            return (from x in db.Reviews where x.Id == reviewId select x).FirstOrDefault();
        }


        public static Review GetReviewByToken(string token)
        {
            return (from review in db.Reviews
                    join detail in db.TransactionDetails on review.TransactionDetailId equals detail.Id
                    where detail.Token.Equals(token)
                    select review).FirstOrDefault();
        }

        public static double GetTotalRatingByReview(int showId)
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

        public static List<Review> GetReviewByDetailId(int showId)
        {
            return (from review in db.Reviews where review.TransactionDetailId == showId select review).ToList();
        }

        public static List<Review> GetShowReviewByShowId(int showId)
        {
            return (from review in db.Reviews
                    join detail in db.TransactionDetails on review.TransactionDetailId equals detail.Id
                    join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                    join show in db.Shows on header.ShowId equals show.Id
                    where show.Id == showId
                    select review).ToList();
        }
    }
}