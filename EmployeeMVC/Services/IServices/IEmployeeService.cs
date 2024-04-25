using EmployeeMVC.Models.DTOs;

namespace EmployeeMVC.Services.IServices
{
	public interface IEmployeeService
	{
		Task<APIResponse> GetAllAsync();
		Task<APIResponse> GetAsync(int id);
		Task<APIResponse> UpdateAsync(EmployeeUpdateDTO dto);
		Task<APIResponse> RemoveAsync(int id);
		Task<APIResponse> CreateAsync(EmployeeCreateDTO dto);
	}

}
