namespace Keeper.WebService.Dto
{
    public class RequestCreationDto
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string TargetVisit { get; set; }
        public string AdditionalFiles { get; set; }
        public Guid EmployeeId { get; set; }
        public List<Guid> VisitorsIds { get; set; } = new List<Guid>();
        public string? StatusDescription { get; set; }
        // status
    }
}
