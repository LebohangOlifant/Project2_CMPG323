using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Company Id Required")]
        public int? EmployeeCount { get; set; }
        [Required(ErrorMessage = "Employee Count Required")]
        public string BusinessTravel { get; set; }
        [Required(ErrorMessage = "Business Travel Required")]
        public int? StockOptionLevel { get; set; }
        [Required(ErrorMessage = "Stock Option Level Required")]
        public int? TotalWorkingYears { get; set; }
        [Required(ErrorMessage = "Total Working Years Required")]
        public int? TrainingTimesLastYear { get; set; }
    }
}
