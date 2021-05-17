using project.Controllers;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.View.HomePage
{
    public partial class HomePage : System.Web.UI.Page
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

        protected void btnShowDetail_Command(object sender, CommandEventArgs e)
        {
            string ShowId = "";

            if (e.CommandName == "Redirect")
            {
                // Cari Row ke berapa nya
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Reference ke Row dari si GridView
                ShowId = gvShows.Rows[rowIndex].Cells[0].Text;
            }

            Response.Redirect("../Shows/ShowDetailPage.aspx?ShowId=" + ShowId);
        }
    }
}