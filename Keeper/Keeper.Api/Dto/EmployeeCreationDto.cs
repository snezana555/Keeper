using Keeper.Library.Models;

namespace Keeper.Api.Dto
{
    public class EmployeeCreationDto
    {
        public string FullName { get; set; }
        public  string? Department { get; set; }
        public string? Section { get; set; }
    
    }
}
