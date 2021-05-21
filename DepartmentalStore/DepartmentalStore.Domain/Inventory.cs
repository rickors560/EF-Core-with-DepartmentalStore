using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class Inventory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int InventoryQuantity { get; set; }
        public bool InStock {
            get {
                return (InventoryQuantity == 0) ? false : true;
            }
        }
    }
}