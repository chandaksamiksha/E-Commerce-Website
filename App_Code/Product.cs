using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{
    public string Name;
    public int Id;
    public string Description;
    public double Price;
    public Product(int id)
    {
        Id = id;
    }
    public string GetProductName()
    {
        return Name;
    }
    public int GetProductId()
    {
        return Id;
    }
    public string GetProductDescription()
    {
        return Description;
    }
    public double GetProductPrice()
    {
        return Price;
    }
}