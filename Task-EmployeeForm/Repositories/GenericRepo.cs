using Microsoft.EntityFrameworkCore;
using Task_EmployeeForm.Data;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Repositories.IRepositories;

namespace Task_EmployeeForm.Repositories
{
	public class GenericRepo<T> : IGenericRepo<T> where T : class 
	{
		private readonly ApplicationDbContext _db;
		private readonly DbSet<T> _dbSet;

		public GenericRepo(ApplicationDbContext db)
		{
			_db = db;
			_dbSet = db.Set<T>();

		}


		public async Task Add(T model)
		{
			await _dbSet.AddAsync(model);
			await Save();
		}

		public async Task Remove(T model)
		{
			_dbSet.Remove(model);
			await Save();
		}

		

		public async Task UpdateEmployee(T model)
		{
			_db.Update(model);
			await Save();

		}
public async Task Save()
		{
			await _db.SaveChangesAsync();
		}


	}
}
