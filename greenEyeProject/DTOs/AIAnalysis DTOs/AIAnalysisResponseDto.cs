using greenEyeProject.DTOs.Recommendation_DTOs;

namespace greenEyeProject.DTOs.AIAnalysis_DTOs
{
    public class AIAnalysisResponseDto
    {
        public int AnalysisId { get; set; }
        public string Status { get; set; }
        public decimal RiskPrediction { get; set; }
        public DateTime AnalyzedAt { get; set; }

        // Relations
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public List<RecommendationDto> Recommendations { get; set; }
    }
}
