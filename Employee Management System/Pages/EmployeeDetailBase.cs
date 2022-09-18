using Employee_Management_System.Services;
using Microsoft.AspNetCore.Components;
using Models;

namespace Employee_Management_System.Pages
{
    public class EmployeeDetailBase :ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();


        [Inject]        
        public IEmployeeService EmployeeService { get; set; }
        [Parameter]
        public int Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id;
            Employee = await EmployeeService.GetEmployee(Id);
        }
    }
}
