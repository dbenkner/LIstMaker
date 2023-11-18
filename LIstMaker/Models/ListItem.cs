using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIstMaker.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ItemName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(11,2)")]
        public decimal ItemPrice { get; set; }  
        public int Qty { get; set; } = 1;
    }
}
