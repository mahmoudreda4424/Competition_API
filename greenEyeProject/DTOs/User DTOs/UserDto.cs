namespace greenEyeProject.DTOs.User_DTOs
{
    public class UserDto
    {
   
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // بدل Location String، نخليه List
        public List<string> Locations { get; set; } = new List<string>();

        public string Role { get; set; }
    }
}
