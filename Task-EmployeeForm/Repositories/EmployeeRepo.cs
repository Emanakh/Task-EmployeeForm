using Microsoft.EntityFrameworkCore;
using Task_EmployeeForm.Data;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Repositories.IRepositories;

namespace Task_EmployeeForm.Repositories
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepo(ApplicationDbContext db): base(db)
        {
            _db = db;
            
        }

        
  //      public async Task Add(Employee model)
  //      {
  //           await _db.Employees.AddAsync(model);
  //          await Save();
  //      }

	

		//public async Task Remove(Employee model)
		//{
  //           _db.Employees.Remove(model);
		//	await Save();
		//}

		//public async Task UpdateEmployee(Employee dto)
		//{
  //           _db.Update(dto);
  //         await Save();

		//}

		//public async Task Save()
  //      {
  //          await _db.SaveChangesAsync();
  //      }


	//public async Task<List<Employee>> GetAllEmployees()
		//{
  //      return await _db.Employees.ToListAsync();
            
		//}
		//public async Task<Employee> GetEmployee(int id)
		//{
		//	return await _db.Employees.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

		//}


    }
}
