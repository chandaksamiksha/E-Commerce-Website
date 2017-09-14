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

        protected void Page_Load(object sender, EventArgs e)
        {
            //string id = Request.QueryString["pid"].ToString();
            CartItems items = null;
            if (Session[_cartItems] == null)
            {
                Label1.Text = "Cart Is Empty";
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
                        SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#");
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
                        Table1.Rows.Add(row);
                    }
                    if (Session["totalPrice"] != null)
                        PayableAmt.Text = Session["totalPrice"].ToString();
                }
                catch
                {
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string orderId = null;
            using (SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"insert into Orders OUTPUT inserted.O_ID values(Current_TimeStamp,'" + Convert.ToInt32(Session["totalPrice"]) + "')", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                orderId = (ds.Tables[0].Rows[0][0]).ToString();
                Table1.Visible = false;
                Label1.Text = "Order Status";
                PayableAmt.Text = "Order Generated";
                Button1.Visible = false;
            }
            CartItems items = null;
            items = (CartItems)(Session[_cartItems]);
            foreach (var item in items.items )
            {
                using (SqlConnection connection = new SqlConnection("Data Source=TAVDESKRENT013;Initial Catalog=Shop;User Id=sa;password=test123!@#"))
                {
                    connection.Open();
                    int p_Id = Convert.ToInt32(item);
                    SqlCommand command = new SqlCommand($"insert into OrderDetails values ({orderId},{p_Id},{Convert.ToInt32(Session["totalPrice"])})",connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    Table1.Visible = false;
                    Label1.Text = "Inserted Into OrderDetails";
                    PayableAmt.Text = "Order Generated";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }

        
    }
}




