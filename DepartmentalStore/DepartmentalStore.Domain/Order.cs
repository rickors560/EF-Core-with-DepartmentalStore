using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}