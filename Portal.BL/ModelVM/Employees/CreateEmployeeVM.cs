using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Portal.BL.ModelVM.Employees
{
    public class CreateEmployeeVM
    {
        [Required]
        [MaxLength(5,ErrorMessage ="Max Length Must be less than 5 char")]
        [MinLength(2, ErrorMessage = "Max Length Must be greater than 2 char")]
        public string FName { get;  set; }
        [Required]
        [MaxLength(5, ErrorMessage = "Max Length Must be less than 5 char")]
        [MinLength(2, ErrorMessage = "Max Length Must be greater than 2 char")]
        public string LName { get;  set; }
        [Required]
        public int Age { get;  set; }
        [Required]
        public double Salary { get;  set; }
        public IFormFile? Image { get; set; }
        public int DeptId { get; set; }
    }
}
