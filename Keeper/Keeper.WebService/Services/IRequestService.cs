using KeeperLibrary.Models;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Services
{
    public interface IRequestService
    {
        Task Add(RequestCreationDto dto);
        Task Remove(int id);
        Task Edit(Request request);
        Task ChangeStatus(int id);
    }
}
