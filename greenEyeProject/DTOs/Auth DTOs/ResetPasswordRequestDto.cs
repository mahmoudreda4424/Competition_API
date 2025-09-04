using System.ComponentModel.DataAnnotations;

namespace greenEyeProject.DTOs.Auth_DTOs
{
    public class ResetPasswordRequestDto
    {
        [Required] public string Email { get; set; }
        [Required] public string OldPassword { get; set; }
        [Required] public string NewPassword { get; set; }
    }
}
