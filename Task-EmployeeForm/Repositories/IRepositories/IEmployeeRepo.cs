using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;

namespace Task_EmployeeForm.Repositories.IRepositories
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        Task UpdateEmployee(Employee dto);
        Task Remove(Employee model);
		
			//Task<List<Employee>> GetAllEmployees();
   //     Task<Employee> GetEmployee(int id);
		Task Add(Employee model);
        Task Save();
    }
}
