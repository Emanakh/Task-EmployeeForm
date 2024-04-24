using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_EmployeeForm.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobRole { get; set; }
        public string Gender { get; set; }
        public bool FirstAppointment { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }

    }
}
