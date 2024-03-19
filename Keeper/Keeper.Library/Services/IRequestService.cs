using Keeper.Library.Models;
using Keeper.Library.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Keeper.Library.Services
{
    public interface IRequestService
    {
        Task Add(RequestCreationDto dto);
        Task Remove(int id); 
        Task Edit(int id,Request request);
        Task<bool> ChangeStatus(int id, string status);
        Task<List<Request>> GetRequestsByClientEmail(string email);
        Task<Request> GetItem(int id);
        Task<List<Request>> GetRequests();
    }
}
