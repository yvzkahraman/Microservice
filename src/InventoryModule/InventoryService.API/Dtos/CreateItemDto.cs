namespace InventoryModule.InventoryService.API.Dtos
{
    public class CreateItemDto
    {
        public string Name { get; set; } = null!;
        public int Rarity { get; set; }
    }
}