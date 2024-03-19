using Keeper.Api.Dto;
using Keeper.Library.Models;

namespace Keeper.Api.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);

        Task<List<Employee>> GetEmployees();

        Task<int> Add(EmployeeCreationDto dto);

        Task Remove(int id);
        Task Edit(int id, EmployeeCreationDto dto);
    }
}
