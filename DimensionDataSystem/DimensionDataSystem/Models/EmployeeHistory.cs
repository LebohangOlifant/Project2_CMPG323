using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class EmployeeHistory
    {
        [Key]
        public int HistoryId { get; set; }
        [Required(ErrorMessage = "History Id Required")]
        public int? NumCompaniesWorked { get; set; }
        [Required(ErrorMessage = "Number of Companies Worked Required")]
        public int? YearsAtCompany { get; set; }
        [Required(ErrorMessage = "Years At Company Required")]
        public int? YearsInCurrentRole { get; set; }
        [Required(ErrorMessage = "Years In Current Role Required")]
        public int? YearsSinceLastPromotion { get; set; }
        [Required(ErrorMessage = "Company Id Required")]
        public int? YearsWithCurrManager { get; set; }
    }
}
