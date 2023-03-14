using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public double Total { get; set; }

    }
}



/*
 namespace CoffeeShop.Models
{
    public class Checkout
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }


    }
}
 
 
 */