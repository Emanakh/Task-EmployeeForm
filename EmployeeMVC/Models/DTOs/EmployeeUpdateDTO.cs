using System.ComponentModel.DataAnnotations;
using static EmployeeMVC.Enums.Enums;

namespace EmployeeMVC.Models.DTOs
{
	public class EmployeeUpdateDTO
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public int JobRole { get; set; }
		public int Gender { get; set; }
		public bool FirstAppointment { get; set; } = false;
		public DateTime StartDate { get; set; }
		public string? Notes { get; set; }
	}
}
