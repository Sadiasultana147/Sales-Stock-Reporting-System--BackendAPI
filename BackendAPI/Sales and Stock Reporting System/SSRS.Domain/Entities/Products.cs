namespace SSRS.Domain
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? SKU { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
