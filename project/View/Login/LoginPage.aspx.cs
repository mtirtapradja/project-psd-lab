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
            // Kalo udah ada cookie, berarti langsung redirect ke HomePage
            if (Request.Cookies["remember"] != null)
            {
                int currentUserID = int.Parse(Request.Cookies["remember"].Value);

                User currentUser = (from x in db.Users where x.Id.Equals(currentUserID) select x)
                                .FirstOrDefault();

                // Kalo user == Buyer redirect ke BuyerHomePage
                if (currentUser.RoleId == 1)
                {
                    Response.Redirect("../HomePage/BuyerHomePage.aspx");
                }
                else
                {
                    Response.Redirect("../HomePage/SellerHomePage.aspx");
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;

            User currentUser = (from x in db.Users where x.Username.Equals(username) && x.Password.Equals(password) select x)
                                .FirstOrDefault();

            if (currentUser != null)
            {
                if (cbRemember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("remember");
                    cookie.Value = currentUser.RoleId.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(cookie);
                }

                if(currentUser.RoleId == 1)
                {
                    Response.Redirect("../HomePage/BuyerHomePage.aspx");
                }
                else
                {
                    Response.Redirect("../HomePage/SellerHomePage.aspx");
                }
                
            }


        }
    }
}