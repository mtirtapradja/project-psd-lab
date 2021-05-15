using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;

namespace project.Repository
{
    public class TransactionRepository
    {
        private static Project_DatabaseEntities2 db = new Project_DatabaseEntities2();

        public static bool InsertTransactionHeader(TransactionHeader trHeader)
        {
            if (trHeader != null)
            {
                db.TransactionHeaders.Add(trHeader);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool InsertTranscationDetail(TransactionDetail trDetail)
        {
            if (trDetail != null)
            {
                db.TransactionDetails.Add(trDetail);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Transaction> GetAllTransaction()
        {
            return (from x in db.TransactionHeaders
                    join y in db.Shows on x.ShowId equals y.Id
                    select new Transaction
                    {
                        Payment_Date = x.CreatedAt,
                        Show_Name = y.Name,
                        Show_Time = x.ShowTime,
                        Quantity = GetTransactionDetails(x.Id).Count(),
                        Total_Price = y.Price*(GetTransactionDetails(x.Id).Count())
                    }).ToList();
        }

        public static List<JoinedTransactionDetail> GetTransactionDetailById(int trHeaderId)
        {
            return (from x in db.TransactionDetails
                    join y in db.Reviews on x.Id equals y.TransactionDetailId
                    join z in db.TransactionHeaders on x.TransactionHeaderId equals z.Id
                    join v in db.Shows on z.ShowId equals v.Id
                    where z.Id == trHeaderId
                    select new JoinedTransactionDetail
                    {
                        Show_Name = v.Name,
                        Average_Rating = GetTotalRatingByReview(x.Id),
                        Description = v.Description,
                        Token = x.Token
                    }).ToList();
        }

        private static List<TransactionDetail> GetTransactionDetails(int trHeaderId)
        {
            return (from x in db.TransactionDetails where x.TransactionHeaderId == trHeaderId select x).ToList();
        }

        private static int GetTotalRatingByReview(int trDetailId)
        {
            return Convert.ToInt32((from x in db.Reviews where x.TransactionDetailId == trDetailId select x.Rating).Average());
        }

        public static List<Review> GetReviewById(int trDetailId)
        {
            return (from x in db.Reviews where x.TransactionDetailId == trDetailId select x).ToList();
        }

        

    }
}