﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project.Models;
using project.Controllers;

namespace project.Views.RedeemToken
{
    public partial class RedeemTokenPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string RoleID;
            if (Session["RoleId"] != null)
            {
                RoleID = Session["RoleId"].ToString();
            }
            else
            {
                RoleID = "-1";
            }

            ShowAdditionalNavBar(RoleID);
        }

        private void ShowAdditionalNavBar(string RoleID)
        {
            // Kalo Buyer
            if (RoleID == "1")
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
            // Kalo Seller
            else if (RoleID == "2")
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
            // Kalo Guest
            else
            {
                Button button = this.Master.FindControl("btnHomeOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnAddShowOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnReportsOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnLoginOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnRegisterOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnTransactionOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnAccountOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnRedeemOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnLogoutOnNav") as Button;
                button.Visible = false;
            }
        }

        protected void btnRedeemToken_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            TransactionDetail trDetail = TransactionController.GetDetailTransactionByToken(token);
            
            if (trDetail != null)
            {
                TransactionHeader trHeader = TransactionController.GetHeaderTransactionById(trDetail.TransactionHeaderId);

                DateTime currentTime = DateTime.Now;
                TimeSpan timeDiff = currentTime - trHeader.ShowTime;

                int minutedDiff = timeDiff.Minutes;
                string showDetailPageUrl = "../Shows/ShowDetailPage.aspx?ShowId=" + trHeader.ShowId;
                    

                if (minutedDiff >= 0  &&  minutedDiff <= 60)
                {
                    Response.Write("<script>");
                    Response.Write($"window.open('{showDetailPageUrl}','_blank')");
                    Response.Write("</script>");
                }
                if (timeDiff.Seconds > 0)
                {
                    string reviewPageUrl = "../Review/ReviewPage.aspx?Token=" + token;
                    Response.Write("<script>");
                    Response.Write($"window.open('{reviewPageUrl}','_self')");
                    Response.Write("</script>");
                }
                else
                {
                    lblError.Text = "Token can't be redeem";
                }
            }
        }
    }
}