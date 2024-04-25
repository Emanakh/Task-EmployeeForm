using Task_EmployeeForm.Models;

namespace Task_EmployeeForm.Repositories.IRepositories
{
	public interface IDapperRepo
	{
		Task<Employee> GetByIdAsync(int id);
		Task<IReadOnlyList<Employee>> GetAllAsync();
	}
}
