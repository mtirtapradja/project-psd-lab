using project.Controllers;
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
            int SellerId = int.Parse(Request.Cookies["remember"].Value);
            string name = txtName.Text;
            string URL = txtURL.Text;
            string description = txtDesc.Text;
            string price = txtPrice.Text;

            string response = ShowController.CheckAddShow(SellerId, name, URL, description, price);

            if (response == "")
            {
                // Do something
                return;
            }
            else
            {
                lblError.Text = response;
            }
        }


    }
}