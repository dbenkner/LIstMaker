using System.ComponentModel.DataAnnotations;

namespace ListMaker.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool isAdmin { get; set; } = false;
    }
}
