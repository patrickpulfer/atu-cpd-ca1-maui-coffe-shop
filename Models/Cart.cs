using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{

    public class CartModel
    {
        public string ProductID { get; set; }
        public int Quantity { get; set; }
    }


    public class CartModel2
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }
        
        public string ProductImage { get; set; }

        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }
    }


}