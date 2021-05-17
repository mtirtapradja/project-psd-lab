using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;

namespace project.Factories
{
    public class ReviewFactory
    {
        public static Review CreateReview(int trDetailId, int rating, string description)
        {
            Review newReview = new Review();
            newReview.TransactionDetailId = trDetailId;
            newReview.Rating = rating;
            newReview.Description = description;
            return newReview;
        }
    }
}