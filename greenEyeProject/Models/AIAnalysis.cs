using System.ComponentModel.DataAnnotations;

namespace greenEyeProject.Models
{
    public class AIAnalysis
    {
        [Key]
        public int AnalysisId { get; set; }
        public string Status { get; set; }  // Fertile, At Risk, Desertified
        public decimal RiskPrediction { get; set; }
        public DateTime AnalyzedAt { get; set; }

        // Foreign Keys
        public int LocationId { get; set; }
        public Location Location { get; set; }

        // Navigation
        public ICollection<Recommendation> Recommendations { get; set; }
    }

}
