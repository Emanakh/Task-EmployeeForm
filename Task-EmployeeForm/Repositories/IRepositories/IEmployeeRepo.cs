using Task_EmployeeForm.Models;

namespace Task_EmployeeForm.Repositories.IRepositories
{
    public interface IEmployeeRepo
    {
        Task Add(Employee model);
        Task Save();
    }
}
