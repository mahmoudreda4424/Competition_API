namespace greenEyeProject.Models
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }
        public string CropType { get; set; }
        public string LandUseStrategy { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Keys
        public int AnalysisId { get; set; }
        public AIAnalysis Analysis { get; set; }
    }

}
