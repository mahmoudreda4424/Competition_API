namespace greenEyeProject.Models
{
    public class SoilData
    {
        public int SoilDataId { get; set; }
        public decimal pH { get; set; }
        public decimal Salinity { get; set; }
        public decimal Carbon { get; set; }
        public string Texture { get; set; }
        public DateTime CollectedAt { get; set; }

        // Foreign Keys
        public int LocationId { get; set; }
        public Location Location { get; set; }

    }
}
