using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class PassportData
    {
        public int Guid { get; set; }
        public int Number { get;set; }
        public int Series { get; set; }
        public Visitor Visitor { get; set; }
    }
}
