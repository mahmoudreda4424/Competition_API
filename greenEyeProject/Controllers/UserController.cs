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

        // ========================
        // GET: api/User/Profile
        // ========================
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
                Role = user.Role.RoleName
            };

            return Ok(profileDto);
        }



        [HttpPut("Profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDto updateDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);

            var user = await _context.Users
                .Include(u => u.Locations)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null) return NotFound("User not found.");

            // تعديل الحقول
            user.Name = updateDto.Name ?? user.Name;
            user.PhoneNumber = updateDto.PhoneNumber ?? user.PhoneNumber;
            user.Email = updateDto.Email ?? user.Email;

            // تعديل الـ Locations (مثال: حذف القديم وإضافة الجديد)
            if (updateDto.Locations.Any())
            {
                user.Locations.Clear();
                foreach (var locName in updateDto.Locations)
                {
                    user.Locations.Add(new Location { LocationName = locName, UserId = user.UserId });
                }
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

