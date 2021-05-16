using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Globalization;
using project.Models;
using project.Controllers;

namespace project.Views.Shows
{
    public partial class ShowDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string RoleId = Request.QueryString["RoleId"];
            showButton(RoleId);
            int ShowId = int.Parse(Request.QueryString["ShowId"]);

            Models.Show show = ShowController.GetShowById(ShowId);

            if(show != null)
            {
                lblNameContent.Text = show.Name;
                lblPriceContent.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", show.Price);
                lblSellerContent.Text = (show.SellerId).ToString();
                lblDescriptionContent.Text = show.Description;
                FillGrid(ShowId);
            }
        }

        private void FillGrid(int id)
        {
            gvReview.DataSource = ShowController.GetReviewsById(id);
            gvReview.DataBind();
        }

        private void showButton(string RoleId)
        {
            this.btnOrder.Visible = true;
            this.btnUpdate.Visible = true;

            //kalau buyer
            if (RoleId.Equals("1"))
            {
                btnUpdate.Visible = false;
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}