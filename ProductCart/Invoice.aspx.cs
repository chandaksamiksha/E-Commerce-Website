using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductCart
{
    public partial class Invoice : System.Web.UI.Page
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ContinueShopping_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Inventory.aspx");
            }
            catch (Exception e1)
            {
                log.Logger(e1.ToString());
                Response.Redirect("~/StartPage.aspx");
            }

        }
    }
}