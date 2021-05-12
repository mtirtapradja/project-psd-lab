using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;
using project.Models;
using project.Models;

namespace project.Views.Show
{
    public partial class ShowDetailPage : System.Web.UI.Page
    {
        string name;
        string s_price;
        string seller;
        string desciption;


        protected void Page_Load(object sender, EventArgs e)
        {
            string RoleId = Request.QueryString["RoleId"];
            showButton(RoleId);
            string ShowId = Request.QueryString["ShowId"];

            name = Request.QueryString["name"];
            s_price = Request.QueryString["price"];
            seller = Request.QueryString["seller"];
            desciption = Request.QueryString["description"];

            lblNameContent.Text = name;
            int price = int.Parse(s_price);
            lblPriceContent.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"),"Rp. {0:N}",price);
            lblSellerContent.Text = seller;
            lblDescriptionContent.Text = desciption;




        }

        private void showButton(string RoleId)
        {
            Button btnOrder = this.FindControl("btnOrder") as Button;
            btnOrder.Visible = true;
            Button btnUpdate = this.FindControl("btnUpdate") as Button;
            btnUpdate.Visible = false;

            //kalau buyer
            if (RoleId.Equals("1"))
            {
                btnUpdate.Visible = false;
            }
            //kalau seller
            else
            {
                btnOrder.Visible = false;
            }
        }

        


    }
}