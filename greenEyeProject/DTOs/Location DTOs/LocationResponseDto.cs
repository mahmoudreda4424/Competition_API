namespace greenEyeProject.DTOs.Location_DTOs
{
    public class LocationResponseDto
    {
        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
