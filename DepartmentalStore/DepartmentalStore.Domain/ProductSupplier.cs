using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class ProductSupplier
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}