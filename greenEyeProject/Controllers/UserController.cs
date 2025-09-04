using AutoMapper;
using greenEyeProject.DTOs.User_DTOs;
using greenEyeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace greenEyeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        [HttpGet("Profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Locations)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return NotFound("User not found.");

            var profileDto = new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Locations = user.Locations.Select(l => l.LocationName).ToList(),
                Role = user.Role.RoleName,
                ProfileImageUrl = user.ProfileImageUrl ?? "https://example.com/default-profile.png"
            };

            return Ok(profileDto);
        }




        [HttpPut("EditProfile")]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] EditProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);
            var user = await _context.Users.FindAsync(userId);

            if (user == null) return NotFound("User not found.");

            // التحديث
            if (!string.IsNullOrEmpty(dto.Name)) user.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.PhoneNumber)) user.PhoneNumber = dto.PhoneNumber;
            if (!string.IsNullOrEmpty(dto.ProfileImageUrl)) user.ProfileImageUrl = dto.ProfileImageUrl;
            if (!string.IsNullOrEmpty(dto.Email)) user.Email = dto.Email;

            if (dto.Locations != null && dto.Locations.Any())
            {
                
                user.Locations.Clear();

                
                foreach (var locName in dto.Locations)
                {
                    user.Locations.Add(new Location { LocationName = locName });
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Profile updated successfully!" });
        }



    }
}

