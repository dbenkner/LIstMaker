using System.ComponentModel.DataAnnotations;

namespace ListMaker.DTOs
{
    public class LogInDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
