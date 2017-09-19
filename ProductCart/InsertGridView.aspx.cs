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
    public partial class InsertGridView : System.Web.UI.Page
    {
        static string constr = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        SqlConnection connection = new SqlConnection(constr);
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string pName = txtProductName.Text;
            string pDescription = txtDescription.Text;
            string pQuantity = txtQuantity.Text;
            Int16 pSupplierId = Convert.ToInt16(txtSupplier.Text);
            int pPrice = Convert.ToInt32(txtPrice.Text);

            try
            {
                SqlCommand command = new SqlCommand("insert into ProductItems values('" + pName + "','" + pDescription + "','" + pQuantity + "','" + pSupplierId + "','" + pPrice + "')", connection);
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