namespace greenEyeProject.DTOs.Recommendation_DTOs
{
    public class RecommendationDto
    {
        public int RecommendationId { get; set; }
        public string CropType { get; set; }
        public string LandUseStrategy { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }

        public int AnalysisId { get; set; }
    }
}
