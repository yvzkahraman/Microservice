namespace InventoryModule.InventoryService.API.Dtos
{
    public class UpdateItemDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Rarity { get; set; }
    }
}