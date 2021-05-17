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

        public static int InsertTransactionHeader(TransactionHeader trHeader)
        {
            if (trHeader != null)
            {
                db.TransactionHeaders.Add(trHeader);
                db.SaveChanges();
                return trHeader.Id;
            }
            else
            {
                return -1;
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
            List<Transaction> QueryTransaction = (from header in db.TransactionHeaders
                                                  join show in db.Shows on header.ShowId equals show.Id
                                                  select new Transaction
                                                  {
                                                      TransactionHeader = header.Id,
                                                      Payment_Date = header.CreatedAt,
                                                      Show_Name = show.Name,
                                                      Show_Time = header.ShowTime,
                                                      Total_Price = show.Price
                                                  }).ToList();
            foreach (Transaction curr in QueryTransaction)
            {
                curr.Quantity = GetTransactionDetails(curr.TransactionHeader).Count();
                curr.Total_Price = curr.Total_Price * GetTransactionDetails(curr.TransactionHeader).Count();
            }
            return QueryTransaction;
        }

        public static List<JoinedTransactionDetail> GetTransactionDetailById(int trHeaderId)
        {

            List<JoinedTransactionDetail> QueryDetail = (from detail in db.TransactionDetails
                                                         join header in db.TransactionHeaders on detail.TransactionHeaderId equals header.Id
                                                         join show in db.Shows on header.ShowId equals show.Id
                                                         where header.Id == trHeaderId
                                                         select new JoinedTransactionDetail
                                                         {
                                                             Show_Id = show.Id,
                                                             Show_Name = show.Name,
                                                             Description = show.Description,
                                                             Token = detail.Token
                                                         }).ToList();
            foreach (JoinedTransactionDetail curr in QueryDetail)
            {
                curr.Average_Rating = Convert.ToInt32(ReviewRepository.GetTotalRatingByReview(curr.Show_Id));
            }
            return QueryDetail;
        }

        public static TransactionDetail GetDetailTransactionByToken(string token)
        {
            return (from x in db.TransactionDetails where x.Token.Equals(token) select x).FirstOrDefault();
        }

        private static List<TransactionDetail> GetTransactionDetails(int trHeaderId)
        {
            return (from detail in db.TransactionDetails where detail.TransactionHeaderId == trHeaderId select detail).ToList();
        }
    }
}