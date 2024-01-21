namespace InventoryModule.InventoryService.API.Dtos
{
    public class CreateInventoryDto
    {
        public string? Name { get; set; }
        public string UserId { get; set; } = null!;
    }
}