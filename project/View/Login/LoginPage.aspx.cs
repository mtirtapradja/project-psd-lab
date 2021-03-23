using project.Model;
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
            if (Request.Cookies["remember"] != null)
            {
                Response.Redirect("https://google.com")
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;

            User user = (from x in db.Users where x.Username.Equals(username) && x.Password.Equals(password) select x).FirstOrDefault();

            if (user != null)
            {
                if (cbRemember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("remember");
                    cookie.Value = user.Id.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("https://google.com");
            }


        }
    }
}