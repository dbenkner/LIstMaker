using ListMaker.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LIstMaker.Models
{
    public class List
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int ListCategoryId { get; set; }
        public virtual ListCategory? ListCategory { get; set; }
    }
}
