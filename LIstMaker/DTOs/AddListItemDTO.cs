namespace ListMaker.DTOs
{
    public class AddListItemDTO
    {
        public string Name { get; set; }
        public decimal ItemPrice { get; set; }
        public int Qty { get; set; }
        public int ListId { get; set; }
    }
}
