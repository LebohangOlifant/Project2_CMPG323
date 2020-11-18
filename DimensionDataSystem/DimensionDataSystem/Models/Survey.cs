using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DimensionDataSystem.Models
{
    public partial class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        [Required(ErrorMessage = "Environment Satisfaction Required")]
        public int? EnvironmentSatisfaction { get; set; }
        [Required(ErrorMessage = "Performance Rating Required")]
        public int? PerformanceRating { get; set; }
        [Required(ErrorMessage = "Relationship Satisfaction Required")]
        public int? RelationshipSatisfaction { get; set; }
        [Required(ErrorMessage = "Job Satisfaction Required")]
        public int? JobSatisfaction { get; set; }
    }
}
