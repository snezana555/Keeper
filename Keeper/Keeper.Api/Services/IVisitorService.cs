using Keeper.Library.Models;
using Keeper.Api.Dto;
using Keeper.Api;


namespace Keeper.Api.Services

{
    public interface IVisitorService
    {
        Task<int> Add(VisitorCreationDto dto);
        Task Remove(int id);
        Task Edit(int id, VisitorCreationDto dto);
        Task<Visitor> GetVisitorById(int id);
        Task<List<Visitor>> GetVisitors();
    }
}
