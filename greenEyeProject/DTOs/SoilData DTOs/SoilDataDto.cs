namespace greenEyeProject.DTOs.SoilData_DTOs
{
    public class SoilDataDto
    {
        public int SoilDataId { get; set; }
        public decimal pH { get; set; }
        public decimal Salinity { get; set; }
        public decimal Carbon { get; set; }
        public string Texture { get; set; }
        public DateTime CollectedAt { get; set; }

        public int LocationId { get; set; }
    }
}
