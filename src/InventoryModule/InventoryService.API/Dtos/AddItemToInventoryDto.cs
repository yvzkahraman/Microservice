namespace InventoryModule.InventoryService.API.Dtos
{
    public class AddItemToInventoryDto
    {
        public string ItemId { get; set; } = null!;
        public string InventoryId { get; set; } = null!;
    }
}