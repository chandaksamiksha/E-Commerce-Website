using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductCart
{
    public partial class DeleteGridView : System.Web.UI.Page
    {
        string p_Name;
        SqlConnection con = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#");

        protected void Page_Load(object sender, EventArgs e)
        {
            p_Name = Request.QueryString["P_Name"].ToString();
            if (!IsPostBack)
            {
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from ProductItems where P_ID=" + p_Name, con);
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:alert('Record Updated Successfully');", true);
                }
                Response.Redirect("~/Admin.aspx");
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin.aspx");
        }
    }
}