using Keeper.Library.Dto;
using Keeper.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keeper.Library.Services
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
