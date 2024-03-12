using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Employee
    {
        public int Guid { get; set; }
        public string FullName { get; set; }
        public Department? Department { get; set; }
        public string? Section { get; set; }

    }
}
