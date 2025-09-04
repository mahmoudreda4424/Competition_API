namespace greenEyeProject.Models
{
    public class SatelliteData
    {
        public int SatelliteDataId { get; set; }
        public decimal NDVI { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CapturedAt { get; set; }

        // Foreign Keys
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
