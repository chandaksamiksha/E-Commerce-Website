using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCart
{
    public class OrderDetails
    {
        public int OrderID { get; }
        public int ProductId { get; }
        public int Price { get; }
        public int Product_Description { get; }
    }
}