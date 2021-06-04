using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.View
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnHomeOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/HomePage.aspx");
        }

        protected void btnAddShowOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Shows/AddShowPage.aspx");
        }

        protected void btnReportsOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Report/ReportPage.aspx");
        }

        protected void btnLoginOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login/LoginPage.aspx");
        }

        protected void btnRegisterOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Register/RegisterPage.aspx");
        }

        protected void btnTransactionOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Transaction/TransactionPage.aspx");
        }
        
        protected void btnAccountOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../UpdateProfile/UpdateProfilePage.aspx");
        }

        protected void btnRedeemOnNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("../RedeemToken/RedeemTokenPage.aspx");
        }

        protected void btnLogoutOnNav_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["remember"] != null)
            {
                Response.Cookies["remember"].Expires = DateTime.Now.AddDays(-1);
            }

            Session.RemoveAll();

            Response.Redirect("../Login/LoginPage.aspx");
        }
    }
}