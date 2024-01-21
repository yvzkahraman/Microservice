namespace InventoryModule.InventoryService.API.Dtos
{
    public class UpdatedInventoryDto
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }

        public string UserId { get; set; } = null!;
    }
}