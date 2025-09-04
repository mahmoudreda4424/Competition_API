namespace greenEyeProject.DTOs.Auth_DTOs
{
    public class ResetPasswordRequestDto
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
