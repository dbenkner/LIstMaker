using System.ComponentModel.DataAnnotations;

namespace LIstMaker.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ItemName { get; set; } = string.Empty;
        public int Qty { get; set; } = 1;
    }
}
