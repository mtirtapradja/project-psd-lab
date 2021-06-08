using project.Controllers;
using project.Models;
using System;
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
        }

        protected void btnTransactionDetail_Command(object sender, CommandEventArgs e)
        {
            string TransactionId = "";
            string TransactionDate = "";
            string Flag = "";

            if (e.CommandName == "Redirect")
            {
                // Cari Row ke berapa nya
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Reference ke Row dari si GridView
                TransactionId = gvTransactions.Rows[rowIndex].Cells[0].Text;
                TransactionDate = gvTransactions.Rows[rowIndex].Cells[3].Text;

                DateTime transactionDate = Convert.ToDateTime(TransactionDate);
                TimeSpan timeDiff = DateTime.Now - transactionDate;
                
                if (timeDiff.Seconds < 0)
                {
                    Flag = "1";
                } 
                
            }

            Response.Redirect("../Transaction/TransactionDetailPage.aspx?TransactionId=" + TransactionId + "&Flag=" + Flag);
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