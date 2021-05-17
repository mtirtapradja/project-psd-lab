using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project.Models;
using project.Controllers;

namespace project.Views.RedeemToken
{
    public partial class RedeemTokenPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hideAllField();
        }

        protected void btnRedeemToken_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            TransactionDetail trDetail = TransactionController.GetDetailTransactionByToken(token);
           
            if (trDetail != null)
            {
                Show currentShow = ShowController.GetShowByToken(token);
                User currentUser = UserController.GetUserById(currentShow.SellerId);
                ShowAllField();
                txtShowName.Text = currentShow.Name;
                txtSellerName.Text = currentUser.Name;
                txtDescription.Text = currentShow.Description;
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

        private void hideAllField()
        {
            lblShowName.Visible = false;
            txtShowName.Visible = false;
            lblSellerName.Visible = false;
            txtSellerName.Visible = false;
            lblDescription.Visible = false;
            txtDescription.Visible = false;
            lblRating.Visible = false;
            TxtRating.Visible = false;
            lblReviewDescription.Visible = false;
            txtReviewDescription.Visible = false;
            btnRate.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }

        private void ShowAllField()
        {
            lblShowName.Visible = true;
            txtShowName.Visible = true;
            lblSellerName.Visible = true;
            txtSellerName.Visible = true;
            lblDescription.Visible = true;
            txtDescription.Visible = true;
            lblRating.Visible = true;
            TxtRating.Visible = true;
            lblReviewDescription.Visible = true;
            txtReviewDescription.Visible = true;
            btnRate.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
        }

    }
}