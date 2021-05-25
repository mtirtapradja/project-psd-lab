using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project.Controllers;
using project.Models;

namespace project.Views.Shows
{
    public partial class OrderShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button button = this.Master.FindControl("btnLoginOnNav") as Button;
            button.Visible = false;
            
            button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = false;


            if (!this.IsPostBack)
            {
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

                int n = int.Parse(DateTime.Now.ToString("HH")) % 23;
                
                for(int i = 0; i <= n; i++)
                {
                    button = this.gvOrder.Rows[i].FindControl("btnOrderShow") as Button;
                    button.Visible = false;

                    Label label = this.gvOrder.Rows[i].FindControl("lblUnavailable") as Label;
                    label.Text = "Unavailable";
                }
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


                // Dari sini kebawah masih kacau balau, besok check lagi karena banyak smell
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