using Models;

namespace EmployeeAPI.Data
{
    public interface IDepartmentRepository
    {   IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
    }
     
}
