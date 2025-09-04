namespace greenEyeProject.DTOs.AIAnalysis_DTOs
{
    public class AIAnalysisRequestDto
    {
        public string Status { get; set; }   // Fertile, At Risk, Desertified
        public decimal RiskPrediction { get; set; }
        public int LocationId { get; set; }
    }
}
