using AutoMapper;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Repositories;
using Task_EmployeeForm.Repositories.IRepositories;
using Task_EmployeeForm.Services.IServices;

namespace Task_EmployeeForm.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepo<Employee> _repo;
        private readonly IMapper _mapper;   
        private readonly IDapperRepo _dapper;   
        public EmployeeService(IMapper mapper, IGenericRepo<Employee> repo, IDapperRepo dabber)
        {
            _mapper = mapper;
            _repo = repo;
            _dapper = dabber;
        }

		public async Task RemoveAsync(Employee dto)
		{
			await _repo.Remove(dto);
		}
		public async Task<Employee> Add(EmployeeDTO dto)
        {
            var newEmployee = _mapper.Map<Employee>(dto);

            await _repo.Add(newEmployee);
            return newEmployee;
        }

		public async Task<IEnumerable<Employee>> GetAllAsync()
		{
            return await _dapper.GetAllAsync();
		}

		public async Task<Employee> GetAsync(int id)
		{
            return await _dapper.GetByIdAsync(id);
		}

		public async Task UpdateAsync(EmployeeUpdateDTO dto)
		{
           
            var employee = _mapper.Map<Employee>(dto);
			 await _repo.Update(employee);
		}




	}
}
