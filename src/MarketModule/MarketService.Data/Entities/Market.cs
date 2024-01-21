namespace MarketModule.MarketService.Data.Entities
{
    public class Market
    {
        public int Id { get; set; }

        public string SellerId { get; set; } = null!;

        public int Price { get; set; }  

        public string? ItemId { get; set; }
    }
}