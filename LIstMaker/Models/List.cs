using System.ComponentModel.DataAnnotations;

namespace LIstMaker.Models
{
    public class List
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
