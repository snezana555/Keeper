using KeeperLibrary.Models;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Services
{
    public interface IRequestService
    {
        Task Add(RequestCreationDto dto);
        Task Remove(int id); 
        Task Edit(Request request);
        Task<bool> ChangeStatus(int id, StatusChangeDto sData);
        Task<List<Request>> GetRequestsByClientEmail(string email);
        Task<Request?> GetItem(int id);
        Task<List<Request>> GetRequests();
    }
}
