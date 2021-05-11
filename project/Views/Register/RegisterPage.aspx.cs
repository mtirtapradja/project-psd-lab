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
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPass.Text;
            int userType = 2;  // Seller

            Project_DatabaseEntities db = new Project_DatabaseEntities();

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