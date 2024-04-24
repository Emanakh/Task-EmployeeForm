using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Models;

namespace Task_EmployeeForm.Services.IServices
{
    public interface IEmployeeService
    {
        Task<Employee> Add(EmployeeDTO dto);

    }
}
