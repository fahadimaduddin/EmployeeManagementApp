using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Range(30000, 100000)]
        public decimal Salary { get; set; }
    }
}
