using System;
using System.Collections.Generic;
using System.Text;

namespace W3Project
{
    public class History
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public DateTime Now { get; set; }
        public History() { }
        public History(string name, int quantity, double totalPrice, DateTime d)
        {

            this.Name = name;
            this.Quantity = quantity;
            this.TotalPrice = totalPrice;
            this.Now = d;
        }



    }
}
