using System.ComponentModel.DataAnnotations;

namespace ListMaker.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;
    }
}
