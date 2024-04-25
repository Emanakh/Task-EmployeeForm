using System.ComponentModel.DataAnnotations;
using static EmployeeMVC.Enums.Enums;

namespace EmployeeMVC.Models.DTOs
{
    public class EmployeeCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a valid Gender ")]
        public JobRole JobRole { get; set; }

        [Required(ErrorMessage = "Please select a valid job role")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please select Date")]

        public bool FirstAppointment { get; set; } = false;
        [Required]
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }
}
