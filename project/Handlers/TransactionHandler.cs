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
        public static int InsertTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createdAt)
        {
            TransactionHeader trHeader = TransactionFactory.CreateTransactionHeader(buyerId, showId, showTime, createdAt);

            if (trHeader != null)
            {
                return TransactionRepository.InsertTransactionHeader(trHeader);
            }
            else
            {
                return -1;
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

        public static TransactionHeader GetTransactionHeaderById(int trHeaderId)
        {
            return TransactionRepository.GetTransactionHeaderById(trHeaderId);
        }

        public static TransactionDetail GetDetailTransactionByToken(string token)
        {
            TransactionDetail trDetail = TransactionRepository.GetDetailTransactionByToken(token);

            if (trDetail != null)
            {
                return trDetail;
            }
            else
            {
                return null;
            }
        }
        
        public static TransactionHeader GetHeaderTransactionById(int trHeaderId)
        {
            TransactionHeader trHeader = TransactionRepository.GetTransactionHeaderById(trHeaderId);

            if (trHeader != null)
            {
                return trHeader;
            }
            else
            {
                return null;
            }
        }

        public static List<TransactionDetail> GetAllTransactionDetailById(int trHeaderId)
        {
            return TransactionRepository.GetTransactionDetails(trHeaderId);
        }

        public static bool DeleteDetailTransactionById(int trHeaderId)
        {
            List<TransactionDetail> transactionDetails = GetAllTransactionDetailById(trHeaderId);

            foreach(TransactionDetail detail in transactionDetails)
            {
                TransactionRepository.DeleteDetails(detail);
            }

            return true;
        }

        public static bool DeleteHeaderTransactionById(int trHeaderId)
        {
            TransactionHeader transactionHeader = TransactionRepository.GetTransactionHeaderById(trHeaderId);
            return TransactionRepository.DeleteHeader(transactionHeader);
        }

        // Ga kepake
        public static bool TokenIsUsed(TransactionDetail trDetail)
        {
            return TransactionRepository.TokenIsUsed(trDetail);
        }
    }
}