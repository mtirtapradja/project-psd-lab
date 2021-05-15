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

        public static List<TransactionHeader> GetTransactionHeaders()
        {
            
        }

    }
}