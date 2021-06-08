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
            hideNavButton();
            string RoleId;

            if (Session["RoleId"] == null)
            {
                RoleId = "-1";
            }
            else
            {
                RoleId = Session["RoleId"].ToString();
            }

            int UserId;
            if (Session["UserId"] == null)
            {
                UserId = -1;
            }
            else
            {
                UserId = int.Parse(Session["UserId"].ToString());
            }

            int ShowId = int.Parse(Request.QueryString["ShowId"]);
            showButton(RoleId,ShowId,UserId);
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

        private void FillGrid(int showId)
        {
            gvReview.DataSource = ReviewController.GetShowReviewByShowId(showId);
            gvReview.DataBind();
        }

        private void hideNavButton()
        {
            Button button = this.Master.FindControl("btnLoginOnNav") as Button;
            button.Visible = false;

            button = this.Master.FindControl("btnRegisterOnNav") as Button;
            button.Visible = false;
        }

        private void navForSeller()
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

        private void showButton(string RoleId, int ShowId,int UserId)
        {
            this.btnOrder.Visible = true;
            this.btnUpdate.Visible = true;

            // Kalau Buyer
            if (RoleId.Equals("1"))
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

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
            // Kalau Seller
            else if (RoleId.Equals("2") && ShowController.CheckShowWithSeller(ShowId,UserId))
            {
                btnOrder.Visible = false;
                navForSeller();
            }
            else
            {
                btnOrder.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                if (!RoleId.Equals("2"))
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
                else
                {
                    navForSeller();
                }
                
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string showId = Request.QueryString["ShowId"];
            Response.Redirect("../Shows/OrderShowPage.aspx?ShowId="+showId);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string showId = Request.QueryString["ShowId"];
            Response.Redirect("../Shows/UpdateShowPage.aspx?ShowId=" + showId);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int showId = Convert.ToInt32(Request.QueryString["ShowId"]);

            List<Models.Review> reviews = ReviewController.GetShowReviewByShowId(showId);

            if (reviews.Count > 0)
            {
                lblError.Text = "Show has been reviewed, can't delete show";
            }
            else
            {
                if (ShowController.DeleteShow(showId))
                {
                    Response.Redirect("../Home/HomePage.aspx");
                }
            }
        }
    }
}