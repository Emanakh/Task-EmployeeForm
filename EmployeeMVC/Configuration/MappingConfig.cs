using AutoMapper;
using EmployeeMVC.Models.DTOs;

namespace EmployeeMVC.Configuration
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<EmployeeDTO, EmployeeUpdateDTO>().ReverseMap();


		}
	}
}
