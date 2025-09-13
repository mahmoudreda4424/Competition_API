using System;
using System.Collections.Generic;

namespace greenEyeProject.DTOs.Report_DTOs
{
    public class ReportResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime AnalysisDate { get; set; }

        public decimal PredictedNdvi { get; set; }
        public string SeverityLevel { get; set; }

        public List<string> KeyDrivers { get; set; } = new List<string>();
        public List<string> Recommendations { get; set; } = new List<string>();
    }
}
