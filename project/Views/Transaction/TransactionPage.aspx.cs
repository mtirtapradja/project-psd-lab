﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.Views.Transaction
{
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowNav();
        }

        protected void btnTransactionDetail_Command(object sender, CommandEventArgs e)
        {
            string TransactionId = "";

            if (e.CommandName == "Redirect")
            {
                // Cari Row ke berapa nya
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Reference ke Row dari si GridView
                TransactionId = gvTransactions.Rows[rowIndex].Cells[0].Text;
            }

            Response.Redirect("../Transaction/TransactionDetailPage.aspx?TransactionId=" + TransactionId);
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
    }
}