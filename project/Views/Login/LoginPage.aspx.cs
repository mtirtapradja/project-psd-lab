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
                        cookie.Value = currentUser.Id.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }

                    Session["UserId"] = currentUser.Id;
                    Session["RoleId"] = currentUser.RoleId;

                    Response.Redirect("../Home/HomePage.aspx");
                }
                else
                {
                    lblError.Text = response;
                }
            }
        }
    }
}