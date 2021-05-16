using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project.Views.Shows
{
    public partial class OrderShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("Time")});
                dt.Rows.Add(1, "01:00");
                dt.Rows.Add(2, "02:00");
                dt.Rows.Add(3, "03:00");
                dt.Rows.Add(4, "04:00");
                dt.Rows.Add(5, "05:00");
                dt.Rows.Add(6, "06:00");
                dt.Rows.Add(7, "07:00");
                dt.Rows.Add(8, "08:00");
                dt.Rows.Add(9, "09:00");
                dt.Rows.Add(10, "10:00");
                dt.Rows.Add(11, "11:00");
                dt.Rows.Add(12, "12:00");
                dt.Rows.Add(13, "13:00");
                dt.Rows.Add(14, "14:00");
                dt.Rows.Add(15, "15:00");
                dt.Rows.Add(16, "16:00");
                dt.Rows.Add(17, "17:00");
                dt.Rows.Add(18, "18:00");
                dt.Rows.Add(19, "19:00");
                dt.Rows.Add(20, "20:00");
                dt.Rows.Add(21, "21:00");
                dt.Rows.Add(22, "22:00");
                dt.Rows.Add(23, "23:00");
                dt.Rows.Add(24, "24:00");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];

                //Fetch value of Name.
                string name = (row.FindControl("txtName") as TextBox).Text;

                //Fetch value of Country
                string country = row.Cells[1].Text;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nCountry: " + country + "');", true);
            }
        }

        protected void btnOrderShow_Click(object sender, EventArgs e)
        {

        }
    }
}