using System.ComponentModel.DataAnnotations;

namespace ListMaker.DTOs
{
    public class AddListCategoryDTO
    {
        [Required,StringLength(60)]
        public string CategoryName { get; set; } = string.Empty;
    }
}
