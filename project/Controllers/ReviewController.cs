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