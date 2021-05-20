using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
using project.Handlers;

namespace project.Controllers
{
    public class ReviewController
    {
        public static string CheckReview(string s_rating, string description)
        {
            string response = "";

            if (s_rating == "")
            {
                response = "Rating must be filled";
            }
            else
            {
                int rating = int.Parse(s_rating);
                if(rating<1 || rating > 5)
                {
                    response = "Rating must be between 1 and 5";
                }
                else if (description == "")
                {
                    response = "Desciption must be filled";
                }
            }
            return response;
        }

        public static bool InsertNewReview(int trDetailId, int rating, string desciption)
        {
            return ReviewHandler.InsertNewReview(trDetailId, rating, desciption);
        }

        public static bool UpdateReview(int reviewId, int rating, string description)
        {
            return ReviewHandler.UpdateReview(reviewId, rating, description);
        }

        public static bool DeleteReview(int reviewId)
        {
            return ReviewHandler.DeleteReview(reviewId);
        }

        public static Review GetReviewByToken(string token)
        {
            return ReviewHandler.GetReviewByToken(token);
        }

        // Method ini gatau buat apa, kayaknya ga kepake
        public static List<Review> GetReviewByShowId(int showId)
        {
            return ReviewHandler.GetReviewByDetailId(showId);
        }

        public static List<Review> GetShowReviewByShowId(int showId)
        {
            return ReviewHandler.GetShowReviewByShowId(showId);
        }
    }
}