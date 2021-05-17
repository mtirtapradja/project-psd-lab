using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project.Models;
using project.Controllers;

namespace project.Views.Review
{
    public partial class ReviewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.QueryString["Token"];

            if (token == null)
            {
                Response.Redirect("../RedeemToken/RedeemTokenPage.aspx");
            }
            else
            {
                Show currentShow = ShowController.GetShowByToken(token);
                User currentSeller = UserController.GetUserById(currentShow.SellerId);
                Models.Review currentReview = ReviewController.GetReviewByToken(token);

                showButton(currentReview);

                lblShowName.Text = currentShow.Name;
                lblShowSellerName.Text = currentSeller.Name;
                lblShowDescription.Text = currentShow.Description;
            }
        }

        private void showButton(Models.Review currentReview)
        {
            if (currentReview == null)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                btnRate.Visible = false;
            }
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}