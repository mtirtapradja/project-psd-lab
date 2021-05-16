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
        public static int CheckTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createAt)
        {
            return TransactionHandler.InsertTransactionHeader(buyerId, showId, showTime, createAt);
        }

        public static bool CheckTransactionDetail(int trHeaderId, int status, string token)
        {
            return TransactionHandler.InsertTransactionDetail(trHeaderId, status, token);
        }

        public static List<Transaction> GetAllTransaction()
        {
            return TransactionHandler.GetAllTransaction();
        }

        public static List<JoinedTransactionDetail> GetTransactionDetailById(int trHeaderId)
        {
            return TransactionHandler.GetTransactionDetailById(trHeaderId);
        }
    }
}