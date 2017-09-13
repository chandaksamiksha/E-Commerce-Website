using System;
using System.Collections.Generic;

namespace ProductCart
{
    public class CartItems
    {
        public List<string> items = new List<string>();
        public void AddItemToCart(string id)
        {
            items.Add(id);
        }
    }
}