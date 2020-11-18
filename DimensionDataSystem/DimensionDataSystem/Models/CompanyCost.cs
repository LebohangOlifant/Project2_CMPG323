using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class CompanyCost
    {
        [Key]
        public int CostId { get; set; }
        [Required(ErrorMessage = "Daily Rate Required")]
        public int? DailyRate { get; set; }
        [Required(ErrorMessage = "Hourly Rate Required")]
        public int? HourlyRate { get; set; }
        [Required(ErrorMessage = "Monthly Income Required")]
        public int? MonthlyIncome { get; set; }
        [Required(ErrorMessage = "Monthly Rate Required")]
        public int? MonthlyRate { get; set; }
        [Required(ErrorMessage = "Percent Salary Hike Required")]
        public int? PercentSalaryHike { get; set; }
        [Required(ErrorMessage = "Standard Hours Required")]
        public int? StandardHours { get; set; }
    }
}
