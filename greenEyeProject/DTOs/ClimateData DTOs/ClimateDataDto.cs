namespace greenEyeProject.DTOs.ClimateData_DTOs
{
    public class ClimateDataDto
    {
        public int ClimateDataId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Rainfall { get; set; }
        public decimal Humidity { get; set; }
        public DateTime CollectedAt { get; set; }

        public int LocationId { get; set; }
    }
}
