using System.ComponentModel.DataAnnotations;

namespace LIstMaker.DTOs
{
    public class LogInDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
