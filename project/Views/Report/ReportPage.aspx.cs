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
            // Kalo udah ada cookie, berarti langsung redirect ke HomePage
            if (Request.Cookies["remember"] != null)
            {
                int currentUserID = int.Parse(Request.Cookies["remember"].Value);

                User currentUser = UserController.GetUserById(currentUserID);

                if (currentUser.RoleId == 1)
                {
                    Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
                }
            }

            // Kalo udah ada session, berarti langsung redirect ke HomePage
            if (Session["UserId"] != null)
            {
                int currentUserID = int.Parse(Session["UserId"].ToString());

                User currentUser = UserController.GetUserById(currentUserID);

                if (currentUser.RoleId == 1)
                {
                    Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
                }
            }

            int sellerId = Convert.ToInt32(Session["UserId"].ToString());
            TransactionReport transactionReport = new TransactionReport();
            transactionReport.SetDataSource(GetData(sellerId));
            crvTransactionDetail.ReportSource = transactionReport;

            showAdditionalNavbar();
        }

        private void showAdditionalNavbar()
        {
            Button button = this.Master.FindControl("btnHomeOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnAddShowOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnReportsOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnLoginOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnTransactionOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnAccountOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnRedeemOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnLogoutOnNav") as Button;
            button.Visible = true;
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
                dataset_shows.Rows.Add(newShowRow);
                
                List<TransactionHeader> headers = TransactionController.GetAllTransactionHeaderByShowId(show.Id); 

                foreach(var header in headers)
                {
                    var newHeaderRow = dataset_transaction_headers.NewRow();
                    newHeaderRow["ShowId"] = header.ShowId;
                    newHeaderRow["BuyerId"] = header.BuyerId;
                    newHeaderRow["CreatedAt"] = header.CreatedAt;

                    List<TransactionDetail> details = TransactionController.GetAllTransactionDetailById(header.Id);

                    newHeaderRow["Quantity"] = details.Count;
                    newShowRow["Price"] = show.Price * details.Count;

                    User user = UserController.GetUserById(header.BuyerId);

                    newHeaderRow["BuyerName"] = user.Name;

                    dataset_transaction_headers.Rows.Add(newHeaderRow);
                }
            }

            return dataset;
        }
    }
}