namespace greenEyeProject.DTOs.SatelliteData_DTOs
{
    public class SatelliteDataDto
    {
        public int SatelliteDataId { get; set; }
        public decimal NDVI { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CapturedAt { get; set; }

        public int LocationId { get; set; }
    }
}
