using Keeper.Library.Models;
using Keeper.Api.Dto;

namespace Keeper.Api.Services
{
    public interface IRequestService
    {
        Task Add(RequestCreationDto dto);
        Task Remove(int id); 
        Task Edit(int id,Request request);
        Task<bool> ChangeStatus(int id, string status);
        Task<List<Request>> GetRequestsByClientEmail(string email);
        Task<Request?> GetItem(int id);
        Task<List<Request>> GetRequests();
    }
}
