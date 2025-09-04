namespace greenEyeProject.DTOs.User_DTOs
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Locations { get; set; } = new List<string>();
    }
}
