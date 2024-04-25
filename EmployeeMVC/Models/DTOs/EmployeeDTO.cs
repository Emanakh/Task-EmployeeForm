using System.ComponentModel.DataAnnotations;
using static EmployeeMVC.Enums.Enums;

namespace EmployeeMVC.Models.DTOs
{
	public class EmployeeDTO
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Job role is required")]
        [EnumDataType(typeof(JobRole), ErrorMessage = "Invalid value for Job Role")]
        public JobRole JobRole { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid value for Gender")]
        public Gender Gender { get; set; }

        [Required]
        public bool FirstAppointment { get; set; } = false;
        [Required]
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }
}
