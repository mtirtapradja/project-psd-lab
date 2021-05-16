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

            Models.ShowDetail show = ShowController.GetShowDetailById(ShowId);

            if(show != null)
            {
                lblNameContent.Text = show.Show_Name;
                lblPriceContent.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", show.Show_Price);
                lblSellerContent.Text = show.Seller_Name;
                lblDescriptionContent.Text = show.Description;
                lblAverageRatingContent.Text = (show.Average_Rating).ToString();

                FillGrid(ShowId);
            }
        }

        private void FillGrid(int Id)
        {
            gvReview.DataSource = ShowController.GetShowReviewsById(Id);
            gvReview.DataBind();

            gvReview.Columns[0].Visible = false;
            gvReview.Columns[1].Visible = false;
        }

        private void showButton(string RoleId)
        {
            this.btnOrder.Visible = true;
            this.btnUpdate.Visible = true;

            // Kalau Buyer
            if (RoleId.Equals("1"))
            {
                Button btnAddShowOnNav = this.Master.FindControl("btnAddShowOnNav") as Button;
                btnAddShowOnNav.Visible = false;
                btnUpdate.Visible = false;
            }
            // Kalau Seller
            else if (RoleId.Equals("2"))
            {
                btnOrder.Visible = false;
            }
            else
            {
                Button btnAddShowOnNav = this.Master.FindControl("btnAddShowOnNav") as Button;
                btnAddShowOnNav.Visible = false;
                btnOrder.Visible = false;
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