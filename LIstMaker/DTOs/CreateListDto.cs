using LIstMaker.Models;
using ListMaker.Models;
namespace ListMaker.DTOs
{
    public class CreateListDto
    {
        public string? Name { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public int ListCategoryId { get; set; }
    }
}
