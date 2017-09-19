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
    public partial class Inventory : System.Web.UI.Page
    {
        private readonly string _cartItems = "CartItems";
        List<string> idOfProduct = new List<string>();
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
                connection.Open();
                SqlCommand command = new SqlCommand("select * from ProductItems", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ProductGrid.DataSource = dataset.Tables[0];
                ProductGrid.DataBind();
            }
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
                Response.Redirect("~/StartPage.aspx");
            }
            finally { connection.Close(); }
        }
        protected void ExtractData(object sender, GridViewCommandEventArgs e)
        {
            CartItems cart = null;
            try
            {
                if (e.CommandName == "AddToCart")
                {
                    int index = Convert.ToInt32((string)e.CommandArgument);
                    GridViewRow row = ProductGrid.Rows[index];
                    string id = row.Cells[0].Text;

                    if (Session["totalPrice"] == null)
                    {
                        Session["totalPrice"] = Convert.ToInt32(row.Cells[3].Text);
                    }
                    else Session["totalPrice"] = (int)Session["totalPrice"] + Convert.ToInt32(row.Cells[3].Text);
                    int totalP = (int)Session["totalPrice"];
                    if (Session[_cartItems] == null)
                    {
                        cart = new CartItems();
                        Session[_cartItems] = cart;
                    }
                    else cart = (CartItems)Session[_cartItems];
                    cart.AddItemToCart(id);
                }
            }
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
                Response.Redirect("~/StartPage.aspx");
            }

        }
        protected void Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Cart.aspx");
            }
  
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
            }

        }

    }
}