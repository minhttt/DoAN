using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Models;

namespace Ecommerce.Models
{
    public class CartItem
    {
        DoAnEntities database = new DoAnEntities();
        public int ProductID { get; set; }
        public string NamePro { get; set; }
        public string ImagePro { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }

        public decimal FinalPrice()
        {
            return Number * Price;
        }

        public CartItem(int productID)
        {
            this.ProductID = productID;
            var productDB = database.Products.Single(s => s.ProductID == this.ProductID);
            this.NamePro = productDB.NamePro;
            this.ImagePro = productDB.ImagePro;
            this.Price = (decimal)productDB.Price;
            this.Number = 1;
        }
    }
}