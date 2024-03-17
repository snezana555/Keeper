using KeeperLibrary.Models;

namespace Keeper.WebService.Dto
{
    public class EmployeeCreationDto
    {
        public string FullName { get; set; }
        public Department? Department { get; set; }
        public string? Section { get; set; }
    
    }
}
