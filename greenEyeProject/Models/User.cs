using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace greenEyeProject.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        // Optionally keep this if you want a default/fallback location
        public string Location { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign Key for Role
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Navigation Properties
        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}
