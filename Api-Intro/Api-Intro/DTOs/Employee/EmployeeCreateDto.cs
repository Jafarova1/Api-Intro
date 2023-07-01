using System.ComponentModel.DataAnnotations;

namespace Api_Intro.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FullName { get; set; }
        public string Adress { get; set; }
    }
}
