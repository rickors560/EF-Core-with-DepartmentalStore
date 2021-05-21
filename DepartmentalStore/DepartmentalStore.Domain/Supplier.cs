using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class Supplier
    {
        public Supplier()
        {
            ProductSuppliers = new List<ProductSupplier>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<ProductSupplier> ProductSuppliers { get; set; }
    }
}