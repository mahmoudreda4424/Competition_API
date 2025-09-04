namespace greenEyeProject.Models
{
    public class ClimateData
    {
        public int ClimateDataId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Rainfall { get; set; }
        public decimal Humidity { get; set; }
        public DateTime CollectedAt { get; set; }

        // Foreign Keys
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }

}
