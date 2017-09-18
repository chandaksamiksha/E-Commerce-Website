using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductCart
{
    public partial class Admin : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                GridBinding();
            }
        }

        protected void GridBinding()
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from ProductItems", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ProductGrid.DataSource = dataset.Tables[0];
                ProductGrid.DataBind();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        protected void ExtractData(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = ProductGrid.Rows[index];
                Response.Redirect("~/UpdateGridView.aspx?P_Name=" + row.Cells[0].Text);
            }
            if (e.CommandName == "DeleteProduct")
            {
                int index = Convert.ToInt32((string)e.CommandArgument);
                GridViewRow row = ProductGrid.Rows[index];
                string id = row.Cells[0].Text;
                Response.Redirect("~/DeleteGridView.aspx?P_Name=" + row.Cells[0].Text);

            }
        }
    }
}