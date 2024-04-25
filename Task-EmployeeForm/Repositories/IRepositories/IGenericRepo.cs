namespace Task_EmployeeForm.Repositories.IRepositories
{
	public interface IGenericRepo< T> where T : class
	{

		 Task Add(T model);
		 Task Remove(T model);
		Task UpdateEmployee(T model);
		Task Save();
	}
}
