namespace greenEyeProject.DTOs.Location_DTOs
{
    public class LocationRequestDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName { get; set; }
        public int UserId { get; set; }
    }
}
