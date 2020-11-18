using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class EmployeeInformation
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Attrition Required")]
        public string Attrition { get; set; }
        [Required(ErrorMessage = "Distance From Home Required")]
        public int? DistanceFromHome { get; set; }
        [Required(ErrorMessage = "Education Required")]
        public int? Education { get; set; }
        [Required(ErrorMessage = "Education Field Required")]
        public string EducationField { get; set; }
        [Required(ErrorMessage = "Over 18 Required")]
        public string Over18 { get; set; }
        [Required(ErrorMessage = "Over Time Required")]
        public string OverTime { get; set; }
        [Required(ErrorMessage = "WorkLife Balance Required")]
        public int? WorkLifeBalance { get; set; }
    }
}
