﻿// User.cs
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
        public string? ProfileImagePath { get; set; }

    }
}
