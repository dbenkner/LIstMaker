using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ListMaker.Models
{
    [Index("UserName", IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string UserName { get; set; } = string.Empty;
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
        public bool isAdmin { get; set; } = false;
        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    }
}
