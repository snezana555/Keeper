using KeeperLibrary.Models;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Services

{
    public interface IVisitorService
    {
        Task<Guid> Add(VisitorCreationDto dto);
        Task Remove(int id);
        Task Edit(Visitor visitor);
    }
}
