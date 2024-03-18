using Keeper.WebService.Dto;
using KeeperLibrary.Models;

namespace Keeper.WebService.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(Guid id);

        Task<List<Employee>> GetEmployees();

        Task<Guid> Add(EmployeeCreationDto dto);

        Task Remove(Guid id);
        Task Edit(Guid id, EmployeeCreationDto dto);
    }
}
