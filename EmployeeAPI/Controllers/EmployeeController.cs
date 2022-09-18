using EmployeeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class EmployeeController : ControllerBase
    {

        private IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {

                return Ok(await employeeRepository.GetEmployees());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retreiving data from the database");
            }
        }




        //[HttpGet("{id:int}")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int employeeId)
        {
            try
            {
                var employee = await employeeRepository.GetEmployee(employeeId);
                if (employee == null) return NotFound();
                return employee;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when retreiving employee");
            }

        }





        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {

            try
            {
                if (employee == null) return BadRequest();
                var newEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.Id }, newEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Server error when creating a new employee");
            }

        }



        [HttpPut("{id:int}")]
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updatedEm = await employeeRepository.UpdateEmployee(employee);
            if(employee != null)
            {

                return await employeeRepository.UpdateEmployee(employee);
            }
            return null;
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {


            try
            {
                var deletedEmployee = await employeeRepository.GetEmployee(id);
                if (deletedEmployee == null)
                {
                    return NotFound($"Employee with {id} not found");

                };
                return await employeeRepository.DeleteEmployee(id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Employee with Id {id} not found");
            }
        }

    }
}
