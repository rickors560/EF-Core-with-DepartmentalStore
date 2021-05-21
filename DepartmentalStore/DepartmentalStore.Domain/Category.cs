using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class Category
    {
        public Category()
        {
            ProductCategories = new List<ProductCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}