using System;
using System.Collections.Generic;
using System.Configuration;
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
        static string constr = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        SqlConnection connection = new SqlConnection(constr);
        Log log = new Log();
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
            catch (Exception e)
            {
                log.Logger(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        protected void ExtractData(object sender, GridViewCommandEventArgs e)
        {
            try
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
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/InsertGridView.aspx");
            }
            catch(Exception e1)
            {
                log.Logger(e1.ToString());
            }
        }
    }
}