using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public List<Employee>? Employees { get; set; }
    }
}
