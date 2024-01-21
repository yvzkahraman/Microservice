namespace MarketModule.MarketService.API.Dtos
{
    public class MarketCreateDto
    {
        public string InventoryId { get; set; } = null!;
        public string SellerId { get; set; } = null!;

        public int Price { get; set; }

        public string? ItemId { get; set; }
    }
}