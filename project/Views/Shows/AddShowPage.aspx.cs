using project.Controllers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.View.Shows
{
    public partial class AddShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            showAdditionalNavbar();

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int SellerId = int.Parse(Session["UserId"].ToString());
            string name = txtName.Text;
            string URL = txtURL.Text;
            string description = txtDesc.Text;
            string price = txtPrice.Text;

            List<Show> Shows = ShowController.GetAllShow();

            bool ShowNameUnique = true;

            foreach (var show in Shows)
            {
                if (name.Equals(show.Name))
                {
                    ShowNameUnique = false;
                }
            }

            string response = "";

            if (ShowNameUnique)
            {
                response = ShowController.CheckAddShow(SellerId, name, URL, description, price);
            }
            else
            {
                response = "Show Name Must be Unique!";
            }

            if (response == "")
            {
                Response.Redirect("../Home/HomePage.aspx");
                return;
            }
            else
            {
                lblError.Text = response;
            }
        }


    }
}