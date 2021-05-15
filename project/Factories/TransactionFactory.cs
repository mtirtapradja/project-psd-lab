using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project.Models;

namespace project.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createdAt)
        {
            TransactionHeader trHeader = new TransactionHeader();
            trHeader.BuyerId = buyerId;
            trHeader.ShowId = showId;
            trHeader.ShowTime = showTime;
            trHeader.CreatedAt = createdAt;
            return trHeader;
        }

        public static TransactionDetail CreateTransactionDetail(int trHeaderId, int statusId, string token)
        {
            TransactionDetail trDetail = new TransactionDetail();
            trDetail.TransactionHeaderId = trHeaderId;
            trDetail.StatusId = statusId;
            trDetail.Token = token;
            return trDetail;
        }
    }
}