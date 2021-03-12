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
        bool allIsValid = false;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void customValidatorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToString(args.Value).Length < 0 || Convert.ToString(args.Value).Length > 30)
            {
                args.IsValid = false;
                allIsValid = false;
            }
            else
            {
                args.IsValid = true;
                allIsValid = true;
            }
        }

        protected void customValidatorUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToString(args.Value).Length < 6 || Convert.ToString(args.Value).Length > 30)
            {
                args.IsValid = false;
                allIsValid = false;
            }
            else
            {
                args.IsValid = true;
                allIsValid = true;
            }
        }

        protected void customValidatorPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToString(args.Value).Length < 6)
            {
                args.IsValid = false;
                allIsValid = false;
            }
            else
            {
                args.IsValid = true;
                allIsValid = true;
            }
        }

        protected void customValidatorConfirmPass_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtConfirmPass.Text.Equals(txtPassword.Text))
            {
                args.IsValid = true;
                allIsValid = true;
            }
            else
            {
                args.IsValid = false;
                allIsValid = false;
            }
        }

        protected void btnRegist_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string userType = "Seller";

            if (ddlRole.SelectedValue.Equals("Buyer"))
            {
                userType = "Buyer";
            }

            /* Tinggal masukin ke databse */

            if (allIsValid)
            {
                Response.Redirect("../Login/LoginPage.aspx");
            }
        }
    }
}