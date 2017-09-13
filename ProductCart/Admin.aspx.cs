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
        private readonly string _cartItems = "CartItems";
        List<string> idOfProduct = new List<string>();
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
            SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#");
            SqlCommand command = new SqlCommand("select * from ProductItems", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ProductGrid.DataSource = dataset.Tables[0];
            ProductGrid.DataBind();
        }
    
        protected void ExtractData(object sender, GridViewCommandEventArgs e)
        {
            CartItems cart = null;
            
            if (e.CommandName == "AddToCart")
            {   
                int index = Convert.ToInt32((string)e.CommandArgument);
                GridViewRow row = ProductGrid.Rows[index];
                string id = row.Cells[0].Text;
                
                Session["i" + row.Cells[0].Text] = row.Cells[3].Text;
                if(Session["totalPrice"]==null)
                {
                    Session["totalPrice"] = Convert.ToInt32(row.Cells[3].Text);
                }
                else Session["totalPrice"] =(int)Session["totalPrice"]+ Convert.ToInt32(row.Cells[3].Text);
                int totalP = (int)Session["totalPrice"];
                if (Session[_cartItems] == null)
                {
                    cart = new CartItems();
                    Session[_cartItems] = cart;
                }
                else cart=(CartItems)Session[_cartItems];
                cart.AddItemToCart(id);
              }

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
                if (idOfProduct.Contains(id))
                {
                    deleteLabel.Text = "*Cannot Delete Product It Is In the Cart";
                }
                else
                {
                    Response.Redirect("~/DeleteGridView.aspx?P_Name=" + row.Cells[0].Text);
                }
            }
        }


        protected void Checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cart.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/InsertGridView.aspx");
        }

    
    }
}




    
            
            
  
