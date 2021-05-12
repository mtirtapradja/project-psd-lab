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
        private static Project_DatabaseEntities db = new Project_DatabaseEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (response == "")
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

                    Response.Redirect("../Home/HomePage.aspx?id=" + currentUser.RoleId);
                }
                else
                {
                    lblError.Text = response;
                }
            }
        }
    }
}