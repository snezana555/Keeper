using KeeperLibrary.Models;
namespace Keeper.WebService.Dto
{
    public class StatusChangeDto
    {
        public string? StatusDescription { get; set; }
        public enum Status
        {
            rejected,
            approved,
            pending
        }
    }
}
