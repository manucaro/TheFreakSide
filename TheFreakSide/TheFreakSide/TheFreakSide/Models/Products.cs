using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheFreakSide.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public int StockQuantity { get; set; }
        public int SoldQuantity { get; set;  }
    }
}