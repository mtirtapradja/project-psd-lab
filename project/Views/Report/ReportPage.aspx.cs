using project.Controllers;
using project.Datasets;
using project.Models;
using project.Report;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.Views.Report
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionReport transactionReport = new TransactionReport();
            transactionReport.SetDataSource(GetDataItem());
            crvTransactionDetail.ReportSource = transactionReport;
        }

        protected DataSet GetData()
        {
            List<Show> shows = ShowController.GetAllShow();
            DataSet dataset = new DataSet();

            var dataset_shows = dataset.Show;
            var dataset_transaction_header = dataset.TransactionHeader;
            var dataset_transaction_detail = dataset.TransactionDetail;
            var dataset_user = dataset.User;

            foreach(var show in shows)
            { 
                var newShowRow = dataset_shows.NewRow();
                newShowRow["Id"] = show.Id;
                newShowRow["Name"] = show.Name;
                newShowRow["TotalPrice"] = show.Price;
                dataset_shows.Rows.Add(newShowRow);

                List<TransactionHeader> headers = TransactionController.GetAllTransactionHeaderByShowId(show.Id); 

                foreach(var header in headers)
                {
                    var newHeaderRow = dataset_transaction_header.NewRow();
                    newHeaderRow["BuyerId"] = header.BuyerId;
                    newHeaderRow["CreatedAt"] = header.CreatedAt;
                    dataset_transaction_header.Rows.Add(newHeaderRow);
                }
            }

            return dataset;
        }
    }
}