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
        }

        protected void btnRedeemToken_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            TransactionDetail trDetail = TransactionController.GetDetailTransactionByToken(token);
           
            if (trDetail != null)
            {
                Response.Redirect("../Views/Review/ReviewPage.aspx?Token=" + token);  
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