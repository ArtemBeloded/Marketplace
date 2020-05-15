using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class LoginUserVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}