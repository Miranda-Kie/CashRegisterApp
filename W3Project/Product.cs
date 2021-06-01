using System;
using System.Collections.Generic;
using System.Text;

namespace W3Project
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product() { }
        public Product(string name, int quantity, double price)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }


    }
}