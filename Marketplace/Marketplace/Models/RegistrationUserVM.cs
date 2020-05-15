using System;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class RegistrationUserVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
    }
}