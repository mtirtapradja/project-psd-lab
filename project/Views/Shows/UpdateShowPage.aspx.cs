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
    public partial class UpdateShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hideNavButton();

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

        private void hideNavButton()
        {
            Button button = this.Master.FindControl("btnLoginOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ShowId = int.Parse(Request.QueryString["ShowId"]);
            string name = txtName.Text;
            string URL = txtURL.Text;
            string description = txtDesc.Text;
            string price = txtPrice.Text;

            string response = ShowController.CheckUpdateShow(ShowId, name, URL, description, price);

            if (response == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Update Success')", true);
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