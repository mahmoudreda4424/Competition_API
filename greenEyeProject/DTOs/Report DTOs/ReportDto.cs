namespace greenEyeProject.DTOs.Report_DTOs
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public string ReportUrl { get; set; }
        public DateTime GeneratedAt { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
    }
}
