using Employee_Management_System.Services;
using Microsoft.AspNetCore.Components;
using Models;

namespace Employee_Management_System.Pages
{

 
    public class EmployeeListBase : ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        protected List<string> list = new List<string>();

        public List<Employee> employees = new List<Employee>();

        protected override async Task OnInitializedAsync()
        {
            employees = (await EmployeeService.GetEmployees()).ToList();
        }

    }
}
