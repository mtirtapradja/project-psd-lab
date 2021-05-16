using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project.Controllers;
using project.Models;

namespace project.Views.UpdateProfile
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.QueryString["UserId"]);

            User currentUser = UserController.GetUserById(userId);

            lblName.Text = currentUser.Name;
            lblCurrPassword.Text = currentUser.Password;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtOldPassword.Text;
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPass.Text;
            int userId = int.Parse(Request.QueryString["UserId"]);

            string reponse = UserController.CheckUpdate(userId, name, oldPassword, newPassword, confirmPassword);

            if (reponse == "")
            {
                if (UserController.UpdateCurrentUser(userId, name, newPassword))
                {
                    txtName.Text = "";
                    txtOldPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPass.Text = "";
                    lblError.Text = "";
                }
            }
            else
            {
                lblError.Text = reponse;
            }


        }
    }
}