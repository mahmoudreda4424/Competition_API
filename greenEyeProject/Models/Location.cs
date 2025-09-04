namespace greenEyeProject.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation
        public ICollection<SatelliteData> SatelliteData { get; set; }
        public ICollection<SoilData> SoilData { get; set; }
        public ICollection<ClimateData> ClimateData { get; set; }
        public ICollection<AIAnalysis> Analyses { get; set; }
        public ICollection<Report> Reports { get; set; }

    }
}
