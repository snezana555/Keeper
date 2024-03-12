using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Department
    {
        public int Guid { get; set; } 
        public string Name { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
