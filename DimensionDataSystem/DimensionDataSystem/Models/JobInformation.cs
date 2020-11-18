using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class JobInformation
    {
        [Key]
        public int JobId { get; set; }
        [Required(ErrorMessage = "Department Required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "JobInvolvement Required")]
        public int? JobInvolvement { get; set; }
        [Required(ErrorMessage = "Job Level Required")]
        public int? JobLevel { get; set; }
        [Required(ErrorMessage = "Job Role Required")]
        public string JobRole { get; set; }
    }
}
