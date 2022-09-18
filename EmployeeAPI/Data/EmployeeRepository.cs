using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EmployeeAPI.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var newEmployee = await employeeDbContext.Employees.AddAsync(employee);
            await employeeDbContext.SaveChangesAsync();
            return newEmployee.Entity;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {

            return await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);

        }

        
        public async Task<Employee> DeleteEmployee(int id)
        {
            var deletedEmployee = await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(deletedEmployee != null)
            {
                employeeDbContext.Employees.Remove(deletedEmployee);
                await employeeDbContext.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updateEmployee = await employeeDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (updateEmployee != null)
            {
                updateEmployee.Firstname = employee.Firstname;
                updateEmployee.Lastname = employee.Lastname;
                updateEmployee.Email = employee.Email;
                updateEmployee.Gender = employee.Gender;
                updateEmployee.Department = employee.Department;
                await employeeDbContext.SaveChangesAsync();
                return updateEmployee;
            }
            return null;
        }
    }
}
