
using Keeper.Library.Models;
using Microsoft.EntityFrameworkCore;
using Keeper.Api.Dto;

namespace Keeper.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly KeeperContext _db;

        public EmployeeService(KeeperContext db)
        {
            _db = db;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _db.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<int> Add(EmployeeCreationDto dto) 
        {
            Employee employee = new Employee()
            {
                FullName = dto.FullName,
                Department = dto.Department,
                Setcion = dto.Section,
            };
            _db.Employees.Add(employee);

            await _db.SaveChangesAsync();
            return employee.Id;
        }
        
        public async Task Remove(int id)
        {
            Employee employee = await _db.Employees.FindAsync(id);

            if(employee == null)
            {
                return;
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(int id, EmployeeCreationDto dto)
        {
            Employee employee = _db.Employees.Find(id);
            employee.FullName = dto.FullName;
            employee.Department = dto.Department;
            employee.Setcion = dto.Section;

            await _db.SaveChangesAsync();
        }
    }
}
