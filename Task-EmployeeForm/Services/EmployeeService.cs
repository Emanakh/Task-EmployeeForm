using AutoMapper;
using Task_EmployeeForm.Data;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;
using Task_EmployeeForm.Repositories;
using Task_EmployeeForm.Repositories.IRepositories;
using Task_EmployeeForm.Services.IServices;

namespace Task_EmployeeForm.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapper _mapper;   
        public EmployeeService(IMapper mapper, IEmployeeRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Employee> Add(EmployeeDTO dto)
        {
            var newEmployee = _mapper.Map<Employee>(dto);

            await _repo.Add(newEmployee);
            return newEmployee;
        } 


    }
}
