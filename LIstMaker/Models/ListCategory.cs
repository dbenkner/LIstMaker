using System.ComponentModel.DataAnnotations;

namespace ListMaker.Models
{
    public class ListCategory
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
