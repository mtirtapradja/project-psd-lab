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

        }

        protected void customValidatorName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(Convert.ToString(args.Value).Length < 0 || Convert.ToString(args.Value).Length > 30)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void customValidatorUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToString(args.Value).Length < 6 || Convert.ToString(args.Value).Length > 30)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void customValidatorPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToString(args.Value).Length < 6)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void customValidatorConfirmPass_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
        }
    }
}