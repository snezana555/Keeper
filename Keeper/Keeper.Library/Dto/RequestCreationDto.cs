
using Keeper.Library.Models;
using System;
using System.Collections.Generic;
namespace Keeper.Library.Dto
{
    public class RequestCreationDto
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TargetVisit { get; set; }
        public string AdditionalFiles { get; set; }
        public int EmployeeId { get; set; }
        public List<int> VisitorsIds { get; set; } = new List<int>();
        public string StatusDescription { get; set; }
        public string Status { get; set; }


    }
}
