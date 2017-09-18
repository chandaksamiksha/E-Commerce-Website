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
    public partial class Cart : System.Web.UI.Page
    {
        private readonly string _cartItems = "CartItems";
        SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#");
        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = Request.QueryString["pid"].ToString();
            CartItems items = null;
            if (Session[_cartItems] == null)
            {
                TotalAmount_Label.Text = "Cart Is Empty";
                Response.Redirect("Inventory.aspx");
            }
            else
            {
                items = (CartItems)Session[_cartItems];
            }
            if (!IsPostBack)
            {
                try
                {
                    DataTable dataset = null;
                    foreach (var item in items.items)
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand($"select P_Description, P_Quantity,P_Price from ProductItems where P_ID='{item}';", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        dataset = new DataTable();
                        adapter.Fill(dataset);
                        TableRow row = new TableRow();
                        int i = 0;
                        while (i < 3)
                        {
                            TableCell cell = new TableCell();
                            cell.Text = dataset.Rows[0][i++].ToString();
                            row.Cells.Add(cell);
                        }
                        Cart_Table.Rows.Add(row);
                    }
                    if (Session["totalPrice"] != null)
                        PayableAmt_Label.Text = Session["totalPrice"].ToString();
                }
                catch
                {
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        protected void PlaceOrderClick(object sender, EventArgs e)
        {
            string orderId = null;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"insert into Orders OUTPUT inserted.O_ID values(Current_TimeStamp,'" + Convert.ToInt32(Session["totalPrice"]) + "')", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                orderId = (ds.Tables[0].Rows[0][0]).ToString();
                Cart_Table.Visible = false;
                TotalAmount_Label.Text = "Order Status";
                PayableAmt_Label.Text = "Order Generated";
                PlaceOrder_Button.Visible = false;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            CartItems items = null;
            items = (CartItems)(Session[_cartItems]);
            foreach (var item in items.items)
            {
                try
                {
                    connection.Open();
                    int p_Id = Convert.ToInt32(item);
                    SqlCommand command = new SqlCommand($"insert into OrderDetails values ({orderId},{p_Id},{Convert.ToInt32(Session["totalPrice"])})", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    Cart_Table.Visible = false;
                    TotalAmount_Label.Text = "Inserted Into OrderDetails";
                    PayableAmt_Label.Text = "Order Generated";
                }
                catch
                {
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected void ContinueShoppingClick(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }


    }
}