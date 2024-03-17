using Keeper.Data;
using KeeperLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly KeeperDbContext _db;

        EmployeeService(KeeperDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            return await _db.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task Add(EmployeeCreationDto dto) 
        {
            Employee employee = new Employee()
            {
                FullName = dto.FullName,
                Department = dto.Department,
                Section = dto.Section,
            };
            _db.Employees.Add(employee);

            await _db.SaveChangesAsync();
        }
        
        public async Task Remove(Guid id)
        {
            Employee employee = await _db.Employees.FindAsync(id);

            if(employee == null)
            {
                return;
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(Guid id, EmployeeCreationDto dto)
        {
            Employee employee = _db.Employees.Find(id);
            employee.FullName = dto.FullName;
            employee.Department = dto.Department;
            employee.Section = dto.Section;

            await _db.SaveChangesAsync();
        }
    }
}
