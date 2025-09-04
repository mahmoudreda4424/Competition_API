namespace greenEyeProject.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportUrl { get; set; }
        public DateTime GeneratedAt { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public User User { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }

}
