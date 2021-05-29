using project.Controllers;
using project.Handlers;
using project.Models;
using project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.Views.Transaction
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowNav();
        }

        protected void ShowNav()
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int transactionHeaderId = int.Parse(Request.QueryString["TransactionId"]);

            DateTime currentTime = DateTime.Now;

            DateTime showTime = TransactionController.GetHeaderTransactionById(transactionHeaderId).ShowTime;

            TimeSpan diff = currentTime - showTime;

            if (diff.Seconds < 0 )
            {
                if (TransactionController.DeleteDetailTransactionById(transactionHeaderId))
                {
                    if (TransactionController.DeleteHeaderTransactionById(transactionHeaderId))
                    {
                        Response.Redirect("../Home/HomePage.aspx");
                    }
                
                }
            }

            return;
        }
    }
}