using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;
using project.Repository;
using project.Factories;

namespace project.Handlers
{
    public class TransactionHandler
    {
        public static bool InsertTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createdAt)
        {
            TransactionHandler trHeader = TransactionFactory.CreateTransactionHeader(buyerId, showId, showTime, createdAt);

            if (trHeader != null)
            {
                return TransactionRepository.InsertTransactionHeader(trHeader);
            }
            else
            {
                return false;
            }
        }

        public static Boolean InsertTransactionDetail(int trHeaderId, int status, string token)
        {
            InsertTransactionDetail trDetail = TransactionFactory.CreateTransactionDetail(trHeaderId, status, token);

            if (trDetail != null)
            {
                return TransactionRepository.InsertTranscationDetail(trDetail);
            }
            else
            {
                return false;
            }

        }


    }
}