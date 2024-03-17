using KeeperLibrary.Models;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Services

{
    public interface IVisitorService
    {
        Task<Guid> Add(VisitorCreationDto dto);
        Task Remove(Guid id);
        Task Edit(Guid id, VisitorCreationDto dto);
        Task<Visitor> GetVisitorById(Guid id);
        Task<List<Visitor>> GetVisitors();
    }
}
