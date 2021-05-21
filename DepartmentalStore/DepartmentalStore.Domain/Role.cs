using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentalStore.Models
{
    public class Role
    {
        public Role()
        {
            Staffs = new List<Staff>();
        }
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }

        public List<Staff> Staffs { get; set; }
    }
}