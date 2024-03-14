using System;
using System.Collections.Generic;
using System.Text;

namespace KeeperLibrary.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TargetVisit { get; set; }
        public string AdditionalFiles { get; set; }
        public Guid EmployeeId { get; set; }
        public List<Visitor> Visitors { get; set; }
        public string? StatusDescription { get; set; }
        public enum Status
        {
            rejected,
            approved,
            pending
        }

    }
}
