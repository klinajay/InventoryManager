using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Domain
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public string ProductCategoryId { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ImageUrl { get; set; }

    }
}
