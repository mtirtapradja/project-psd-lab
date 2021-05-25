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
            string RoleID;

            if (Session["RoleId"] != null)
            {
                RoleID = Session["RoleId"].ToString();
            }
            else
            {
                if (Request.Cookies["remember"] != null)
                {
                    RoleID = Request.Cookies["remember"].Value;
                }
                else
                {
                    RoleID = "-1";
                }
            }
            ShowAdditionalNavBar(RoleID);

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
                showRating(currentReview);

                lblShowName.Text = currentShow.Name;
                lblShowSellerName.Text = currentSeller.Name;
                lblShowDescription.Text = currentShow.Description;
            }
        }

        private void ShowAdditionalNavBar(string RoleID)
        {
            // Kalo Buyer
            if (RoleID == "1")
            {
                Button button = this.Master.FindControl("btnHomeOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnAddShowOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnReportsOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnLoginOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnRegisterOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnTransactionOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnAccountOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnRedeemOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnLogoutOnNav") as Button;
                button.Visible = true;
            }
            // Kalo Seller
            else if (RoleID == "2")
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
            // Kalo Guest
            else
            {
                Button button = this.Master.FindControl("btnHomeOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnAddShowOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnReportsOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnLoginOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnRegisterOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnTransactionOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnAccountOnNav") as Button;
                button.Visible = false;

                button = this.Master.FindControl("btnRedeemOnNav") as Button;
                button.Visible = true;

                button = this.Master.FindControl("btnLogoutOnNav") as Button;
                button.Visible = false;
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

        private void showRating(Models.Review currentReview)
        {
            if (currentReview != null)
            {
                string s_rating = currentReview.Rating.ToString();
                string description = currentReview.Description;
                lblRatingContain.Text = string.Concat(lblRatingContain.Text,s_rating);
                lblDescriptionContain.Text = string.Concat(lblDescriptionContain.Text, description); 
            }
            else
            {
                lblRatingContain.Visible = false;
                lblDescriptionContain.Visible = false;
            }
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
            string s_rating = txtRating.Text;
            string description = txtDescription.Text;
            string token = Request.QueryString["Token"];

            string response = ReviewController.CheckReview(s_rating, description);

            if(response != "")
            {
                lblError.Text = response;
            }
            else
            {
                int rating = int.Parse(s_rating);
                TransactionDetail trDetail = TransactionController.GetDetailTransactionByToken(token);
                ReviewController.InsertNewReview(trDetail.Id,rating, description);
                lblError.Text = "";
                Response.Redirect("ReviewPage.aspx?Token="+token);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string s_rating = txtRating.Text;
            string description = txtDescription.Text;
            string token = Request.QueryString["Token"];

            string response = ReviewController.CheckReview(s_rating, description);

            if (response != "")
            {
                lblError.Text = response;
            }
            else
            {
                int rating = int.Parse(s_rating);
                Models.Review review = ReviewController.GetReviewByToken(token);
                ReviewController.UpdateReview(review.Id, rating, description);
                lblError.Text = "";
                Response.Redirect("ReviewPage.aspx?Token=" + token);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["Token"];
            Models.Review review = ReviewController.GetReviewByToken(token);
            if (review != null)
            {
                ReviewController.DeleteReview(review.Id);
                lblError.Text = "";
                Response.Redirect("ReviewPage.aspx?Token=" + token);
            }
        }
    }
}