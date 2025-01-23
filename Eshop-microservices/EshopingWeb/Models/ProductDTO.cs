namespace EshopingWeb.Models
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ProductResponse
    {
        public IEnumerable<ProductDTO> Data { get; set; }
    }
}
