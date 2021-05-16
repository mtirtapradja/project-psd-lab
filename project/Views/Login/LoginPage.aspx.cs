using project.Models;
using project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private static Project_DatabaseEntities2 db = new Project_DatabaseEntities2();

        protected void Page_Load(object sender, EventArgs e)
        {
            Button button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = true;
            
            button = this.Master.FindControl("btnLoginOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnAddShowOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnRedeemOnNav") as Button;
            button.Visible = false;

            // Kalo udah ada cookie, berarti langsung redirect ke HomePage
            if (Request.Cookies["remember"] != null)
            {
                int currentUserID = int.Parse(Request.Cookies["remember"].Value);

                User currentUser = (from x in db.Users where x.Id.Equals(currentUserID) select x)
                                .FirstOrDefault();

                Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;

            string response = UserController.CheckLogin(username,password);

            if (response != "")
            {
                lblError.Text = response;
            }
            else
            {
                User currentUser = UserController.Login(username, password);

                if (currentUser != null)
                {
                    lblError.Text = "";
                    if (cbRemember.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("remember");
                        cookie.Value = currentUser.RoleId.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        Session["UserId"] = currentUser.Id;
                    }

                    Response.Redirect("../Home/HomePage.aspx?RoleId=" + currentUser.RoleId);
                }
                else
                {
                    lblError.Text = response;
                }
            }
        }
    }
}