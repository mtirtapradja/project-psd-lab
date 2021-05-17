using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
using project.Repository;
using project.Factories;

namespace project.Handlers
{
    public class ReviewHandler
    {
        public static bool InsertNewReview(int trDetailId, int rating, string desciption)
        {
            Review newReview = ReviewFactory.CreateReview(trDetailId, rating, desciption);

            if (newReview != null)
            {
                return ReviewRepository.InsertNewReview(newReview);
            }
            return false;
        }

        public static bool UpdateReview(int reviewId,int rating, string description)
        {
            Review currentReview = ReviewRepository.GetReviewById(reviewId);

            if(currentReview != null)
            {
                currentReview.Rating = rating;
                currentReview.Description = description;
                return ReviewRepository.UpdateReview(currentReview);
            }
            return false;
        }

        public static bool DeleteReview(int reviewId)
        {
            Review currentReview = ReviewRepository.GetReviewById(reviewId);

            if (currentReview != null)
            {
                return ReviewRepository.DeleteReview(currentReview);
            }
            return false;
        }

        public static Review GetReviewByToken(string token)
        {
            return ReviewRepository.GetReviewByToken(token);
        }

        public static List<Review> GetReviewByDetailId(int showId)
        {
            return ReviewRepository.GetReviewByDetailId(showId);
        }

        public static List<Review> GetShowReviewByShowId(int showId)
        {
            return ReviewRepository.GetShowReviewByShowId(showId);
        }

    }
}