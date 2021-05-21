using System.Collections.Generic;

namespace DepartmentalStore.Models
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            Prices = new List<Price>();
            ProductSuppliers = new List<ProductSupplier>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        public List<Price> Prices { get; set; }
        public Inventory Inventory { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
    }
}