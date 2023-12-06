using System.ComponentModel.DataAnnotations;

namespace ListMaker.DTOs
{
    public class ResetPasswordDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required] public string? CurrentPassword { get; set; }
        [Required] public string? NewPassword { get; set; }
    }
}
