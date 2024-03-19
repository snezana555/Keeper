using Keeper.Library.Models;
using Keeper.Library.Dto;
using Keeper.Library;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Keeper.Library.Services

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
