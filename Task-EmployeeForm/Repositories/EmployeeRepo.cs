using Task_EmployeeForm.Data;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Repositories.IRepositories;

namespace Task_EmployeeForm.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(Employee model)
        {
             await _db.Employees.AddAsync(model);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }



    }
}
