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
            int userId = int.Parse(Session["UserId"].ToString());

            User currentUser = UserController.GetUserById(userId);

            lblName.Text = currentUser.Name;
            lblCurrPassword.Text = currentUser.Password;

            //Button Visibility
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