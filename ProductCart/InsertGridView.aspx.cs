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
        
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
            //            BindTextBoxvalues();
                }
            }

        //private void BindTextBoxvalues()
        //{
        //        string constr = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        //        SqlConnection con = new SqlConnection(constr);
        //        SqlCommand cmd = new SqlCommand("select P_Name,P_Description,P_Quantity,P_SupplierId,P_Price from ProductItems where P_ID=" + p_Name, con);
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        txtProductName.Text = dt.Rows[0][0].ToString();
        //        txtDescription.Text = dt.Rows[0][1].ToString();
        //        txtQuantity.Text = dt.Rows[0][2].ToString();
        //        txtSupplier.Text = dt.Rows[0][3].ToString();
        //        txtPrice.Text = dt.Rows[0][4].ToString();
        //    }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string p_Name = txtProductName.Text;
            string p_Description = txtDescription.Text;
            string p_Quantity = txtQuantity.Text;
            Int16  p_SupplierId = Convert.ToInt16(txtSupplier.Text);
            int p_Price = Convert.ToInt32(txtPrice.Text);
            SqlCommand cmd = new SqlCommand("insert into ProductItems values('" + p_Name + "','" + p_Description + "','" + p_Quantity + "','" + p_SupplierId + "','" + p_Price + "')", con);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowSuccess", "javascript:alert('Record Updated Successfully');", true);
            }
            Response.Redirect("~/Inventory.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inventory.aspx");
        }
    }
}