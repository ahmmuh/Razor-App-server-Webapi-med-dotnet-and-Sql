using EmployeeAPI.Models;
using Models;

namespace EmployeeAPI.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private EmployeeDbContext employeeDbContext;

        public DepartmentRepository(EmployeeDbContext employeeDb)
        {
            this.employeeDbContext = employeeDb;
        }

        public Department GetDepartment(int id)
        {
            return employeeDbContext.Departments.FirstOrDefault(department => department.DepartmentId == id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return employeeDbContext.Departments;
        }
    }
}
