using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollUp
{
    public class Products
    {
        public float? Price { get; set; }
        public string Product { get; set; }
        public string Variant { get; set; }
        public string Gtin { get; set; }

        public Products(float? price, string product, string variant, string gtin)
        {
            Price = price;
            Product = product;
            Variant = variant;
            Gtin = gtin;
        }

    }
}
