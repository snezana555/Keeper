using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public string? Department { get; set; }
        public string? Section { get; set; }

    }
}
