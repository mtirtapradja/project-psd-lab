using project.Controllers;
using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnAddShowOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnRedeemOnNav") as Button;
            button.Visible = false;


            // Kalo udah ada cookie, berarti langsung redirect ke HomePage
            if (Request.Cookies["remember"] != null)
            {
                int currentUserID = int.Parse(Request.Cookies["remember"].Value);

                User currentUser = UserController.GetUserById(currentUserID);

                Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
            }

            // Kalo udah ada session, berarti langsung redirect ke HomePage
            if (Session["UserId"] != null)
            {
                int currentUserID = int.Parse(Session["UserId"].ToString());

                User currentUser = UserController.GetUserById(currentUserID);

                Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPass.Text;
            int userType = 2;  // Seller

            if (ddlRole.SelectedValue.Equals("Buyer"))
            {
                userType = 1; // Buyer
            }

            string response = UserController.CheckRegister(name, username, password, confirmPassword);

            if (response == "")
            {
                UserController.AddNewUser(name, username, password, userType);
                lblError.Text = "";
                Response.Redirect("../Login/LoginPage.aspx");
            }
            else
            {
                lblError.Text = response;
            }
        }
    }
}