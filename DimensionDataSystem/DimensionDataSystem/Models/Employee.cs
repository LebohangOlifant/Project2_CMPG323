using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class Employee
    {
        [Key]
        [Required(ErrorMessage = "Employee Number Required")]
        public int EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Age Required")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Marital Status Required")]
        public string MaritalStatus { get; set; }
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
    }
}
