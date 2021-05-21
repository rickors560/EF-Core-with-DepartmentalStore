using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}