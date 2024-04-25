using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Models;

namespace Task_EmployeeForm.Services.IServices
{
    public interface IEmployeeService
    {
		Task RemoveAsync(Employee dto);
		Task UpdateAsync(EmployeeUpdateDTO dto);
		Task<Employee> GetAsync(int id);

		Task<IEnumerable<Employee>> GetAllAsync();
		Task<Employee> Add(EmployeeDTO dto);

    }
}
