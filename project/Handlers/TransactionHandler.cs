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
            TransactionHeader trHeader = TransactionFactory.CreateTransactionHeader(buyerId, showId, showTime, createdAt);

            if (trHeader != null)
            {
                return TransactionRepository.InsertTransactionHeader(trHeader);
            }
            else
            {
                return false;
            }
        }

        public static bool InsertTransactionDetail(int trHeaderId, int status, string token)
        {
            TransactionDetail trDetail = TransactionFactory.CreateTransactionDetail(trHeaderId, status, token);

            if (trDetail != null)
            {
                return TransactionRepository.InsertTranscationDetail(trDetail);
            }
            else
            {
                return false;
            }

        }

        public static List<Transaction> GetAllTransaction() 
        {
            return TransactionRepository.GetAllTransaction();
        }

        public static List<JoinedTransactionDetail> GetTransactionDetailById(int trHeaderId)
        {
            return TransactionRepository.GetTransactionDetailById(trHeaderId);
        }

    }
}