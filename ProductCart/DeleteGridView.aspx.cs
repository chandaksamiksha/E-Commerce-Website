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
        static string constr = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        SqlConnection connection = new SqlConnection(constr);
        Log log = new Log();
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
                SqlCommand command = new SqlCommand("delete from ProductItems where P_ID=" + p_Name, connection);
                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:alert('Record Updated Successfully');", true);
                }
                Response.Redirect("~/Admin.aspx");
            }
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Admin.aspx");
            }
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
           }
        }
    }
}