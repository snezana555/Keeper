using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TargetVisit { get; set; }
        public byte[] DopFile { get; set; }
        public int IdEmployee { get; set; }
        public int IdVisitorsList { get; set; }
        public string Status { get; set; }
        public string? StatusDescription { get; set; }

    }
}
