using AutoMapper;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Models.DTOs;

namespace Task_EmployeeForm.Configuration
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();


        }
    }
}
