using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cart
/// </summary>
public class Cart
{
    public Product Product { get; }
    public int Quantity { get; }

    public Cart(Product product,int quantity)
    {
        Product.Id = product.Id;
        Product.Name = product.Name;
        Product.Price = product.Price;
        Quantity = quantity;
    }
}