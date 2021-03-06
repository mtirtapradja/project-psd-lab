using project.Controllers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.Views.Shows
{
    public partial class OrderShowPage : System.Web.UI.Page
    {
        private DateTime currentTime = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kalo udah ada cookie, berarti langsung redirect ke HomePage
            if (Request.Cookies["remember"] != null)
            {
                int currentUserID = int.Parse(Request.Cookies["remember"].Value);

                User currentUser = UserController.GetUserById(currentUserID);

                if (currentUser.RoleId == 2)
                {
                    Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
                }
            }

            // Kalo udah ada session, berarti langsung redirect ke HomePage
            if (Session["UserId"] != null)
            {
                int currentUserID = int.Parse(Session["UserId"].ToString());

                User currentUser = UserController.GetUserById(currentUserID);

                if (currentUser.RoleId == 2)
                {
                    Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
                }
            }

            if (IsPostBack)
            {
                ClientScriptManager cs = Page.ClientScript;
                String cbReference = cs.GetCallbackEventReference("'" +
                    Page.UniqueID + "'", "arg", "ReceiveServerData", "", "ProcessCallBackError", false);
                String callbackScript = "function CallTheServer(arg, context) {" + cbReference + "; }";
                cs.RegisterClientScriptBlock(this.GetType(), "CallTheServer", callbackScript, true);

            }
            else
            {
                BindData();
            }
        }

        protected void BindData()
        {
            int ShowId = int.Parse(Request.QueryString["ShowId"]);
            ShowDetail show = ShowController.GetShowDetailById(ShowId);
            Button button;

            if (show != null)
            {
                lblDescriptionValue.Text = show.Description;
                lblRatingValue.Text = show.Average_Rating.ToString();
                lblPriceValue.Text = show.Show_Price.ToString();
                lblShowNameValue.Text = show.Show_Name;
                lblSellerNameValue.Text = show.Seller_Name;
            }

            showAdditionalNavbar();

            string orderDate = txtOrderDate.Text;

            if (orderDate == "")
            {
                orderDate = DateTime.Now.Date.ToString();
            }

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Time") });
            dt.Rows.Add(1, "00:00 - 00:59");
            dt.Rows.Add(2, "01:00 - 01:59");
            dt.Rows.Add(3, "02:00 - 02:59");
            dt.Rows.Add(4, "03:00 - 03:59");
            dt.Rows.Add(5, "04:00 - 04:59");
            dt.Rows.Add(6, "05:00 - 05:59");
            dt.Rows.Add(7, "06:00 - 06:59");
            dt.Rows.Add(8, "07:00 - 07:59");
            dt.Rows.Add(9, "08:00 - 08:59");
            dt.Rows.Add(10, "09:00 - 09:59");
            dt.Rows.Add(11, "10:00 - 10:59");
            dt.Rows.Add(12, "11:00 - 11:59");
            dt.Rows.Add(13, "12:00 - 12:59");
            dt.Rows.Add(14, "13:00 - 13:59");
            dt.Rows.Add(15, "14:00 - 14:59");
            dt.Rows.Add(16, "15:00 - 15:59");
            dt.Rows.Add(17, "16:00 - 16:59");
            dt.Rows.Add(18, "17:00 - 17:59");
            dt.Rows.Add(19, "18:00 - 18:59");
            dt.Rows.Add(20, "19:00 - 19:59");
            dt.Rows.Add(21, "20:00 - 20:59");
            dt.Rows.Add(22, "21:00 - 21:59");
            dt.Rows.Add(23, "22:00 - 22:59");
            dt.Rows.Add(24, "23:00 - 23:59");

            gvOrder.DataSource = dt;
            gvOrder.DataBind();


            DateTime targetTime = Convert.ToDateTime(orderDate);
            TimeSpan timeDiff = currentTime - targetTime;

            int n = Convert.ToInt32(timeDiff.TotalHours);

            if (n < 0)
            {
                n = -1;
            }
            else if (n > 23)
            {
                n = 23;
            }

            for (int i = 0; i <= n; i++)
            {
                button = this.gvOrder.Rows[i].FindControl("btnOrderShow") as Button;
                button.Visible = false;

                Label label = this.gvOrder.Rows[i].FindControl("lblUnavailable") as Label;
                label.Text = "Unavailable";
            }

            List<int> alreadyOrderedAt = isAlreadyOrder(orderDate);

            foreach (int index in alreadyOrderedAt)
            {
                button = this.gvOrder.Rows[index].FindControl("btnOrderShow") as Button;
                button.Visible = false;

                Label label = this.gvOrder.Rows[index].FindControl("lblUnavailable") as Label;
                label.Text = "Unavailable";
            }
        }

        protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Order")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                string orderDate = txtOrderDate.Text;

                string time = orderDate + " " + rowIndex + ":00:00";
                DateTime date = Convert.ToDateTime(time);


                int showId = int.Parse(Request.QueryString["ShowId"]);
                int buyerId = int.Parse(Session["UserId"].ToString());

                if (txtOrderDate.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Choose Order Date')", true);
                }
                else if (txtQuantity.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Insert Quantity')", true);
                }
                else
                {
                    int qty = Convert.ToInt32(txtQuantity.Text);
                    if (qty < 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please insert more than 1 quantity')", true);
                    }
                    else
                    {
                        int headerId = TransactionController.InsertTransactionHeader(buyerId, showId, date, DateTime.Now);

                        if (headerId != -1)
                        {
                            for (int i = 0; i < Convert.ToInt32(txtQuantity.Text); i++)
                            {
                                string token;
                                do
                                {
                                    token = TransactionController.GetRandomToken(6);
                                    TransactionDetail trDetail = TransactionController.GetDetailTransactionByToken(token);
                                    if (trDetail == null)
                                    {
                                        break;
                                    }
                                } while (true);

                                TransactionController.InsertTransactionDetail(headerId, 1, token);
                            }
                        }   
                        Response.Redirect("../Home/HomePage.aspx");
                    }
                }
            }
        }

        private void showAdditionalNavbar()
        {
            Button button = this.Master.FindControl("btnHomeOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnAddShowOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnReportsOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnLoginOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnTransactionOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnAccountOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnRedeemOnNav") as Button;
            button.Visible = true;

            button = this.Master.FindControl("btnLogoutOnNav") as Button;
            button.Visible = true;
        }

        private List<int> isAlreadyOrder(string orderDate)
        {
            List<int> indexRes = new List<int>();

            int ShowId = int.Parse(Request.QueryString["ShowId"]);
            List <TransactionHeader> transactionHeaders = TransactionController.GetAllTransactionHeaderByShowId(ShowId);

            if (transactionHeaders != null)
            {
                foreach (var header in transactionHeaders)
                {
                    DateTime bookedAt = header.ShowTime;
                    string str_bookedAt = String.Format("{0:MM/dd/yyyy}", bookedAt);
                    DateTime order = Convert.ToDateTime(orderDate);
                    string str_orderDate = String.Format("{0:MM/dd/yyyy}", order);

                    if (str_orderDate == str_bookedAt)
                    {
                        int hour =  header.ShowTime.Hour;
                        indexRes.Add(hour);
                    }
                }
            }

            return indexRes;
        }

        protected void txtOrderDate_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}