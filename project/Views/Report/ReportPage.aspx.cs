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
            int sellerId = Convert.ToInt32(Session["UserId"].ToString());
            TransactionReport transactionReport = new TransactionReport();
            transactionReport.SetDataSource(GetData(sellerId));
            crvTransactionDetail.ReportSource = transactionReport;
        }

        protected DataSet GetData(int sellerId)
        {
            // Harusnya munculin cuma show yang dijual sama si seller
            List<Show> shows = ShowController.GetShowBySellerId(sellerId);
            DataSet dataset = new DataSet();

            var dataset_shows = dataset.Show;
            var dataset_transaction_headers = dataset.TransactionHeader;
            var dataset_transaction_details = dataset.TransactionDetail;
            var dataset_users = dataset.User;

            foreach(var show in shows)
            { 
                var newShowRow = dataset_shows.NewRow();
                newShowRow["Id"] = show.Id;
                newShowRow["Name"] = show.Name;
                //newShowRow["TotalPrice"] = show.Price;
                dataset_shows.Rows.Add(newShowRow);

                List<TransactionHeader> headers = TransactionController.GetAllTransactionHeaderByShowId(show.Id); 

                foreach(var header in headers)
                {
                    var newHeaderRow = dataset_transaction_headers.NewRow();
                    newHeaderRow["ShowId"] = header.ShowId;
                    newHeaderRow["BuyerId"] = header.BuyerId;
                    newHeaderRow["CreatedAt"] = header.CreatedAt;
                    dataset_transaction_headers.Rows.Add(newHeaderRow);
                }
            }

            return dataset;
        }
    }
}