using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Handlers;
using project.Models;

namespace project.Controllers
{
    public class TransactionController
    {
        public static int InsertTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createAt)
        {
            return TransactionHandler.InsertTransactionHeader(buyerId, showId, showTime, createAt);
        }

        public static bool InsertTransactionDetail(int trHeaderId, int status, string token)
        {
            return TransactionHandler.InsertTransactionDetail(trHeaderId, status, token);
        }

        public static List<Transaction> GetAllTransaction()
        {
            return TransactionHandler.GetAllTransaction();
        }

        public static TransactionDetail GetDetailTransactionByToken(string token)
        {
            return TransactionHandler.GetDetailTransactionByToken(token);
        }

        public static TransactionHeader GetHeaderTransactionById(int trHeaderId)
        {
            return TransactionHandler.GetHeaderTransactionById(trHeaderId);
        }

        public static string GetRandomToken(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static List<TransactionHeader> GetAllTransactionHeaderByShowId(int showId)
        {
            return TransactionHandler.GetAllTransactionHeaderByShowId(showId);
        }

        public static List<TransactionDetail> GetAllTransactionDetailById(int trHeaderId)
        {
            return TransactionHandler.GetAllTransactionDetailById(trHeaderId);
        }

        public static bool DeleteDetailTransactionById(int trHeaderId)
        {
            return TransactionHandler.DeleteDetailTransactionById(trHeaderId); ;
        }
        public static bool DeleteHeaderTransactionById(int trHeaderId)
        {
            return TransactionHandler.DeleteHeaderTransactionById(trHeaderId); ;
        }

        // Ga kepake
        public static bool TokenIsUsed(TransactionDetail trDetail)
        {
            return TransactionHandler.TokenIsUsed(trDetail);
        }

    }
}