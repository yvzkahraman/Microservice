using System.Reflection;
using InventoryModule.InventoryService.API.Dtos;
using InventoryModule.InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryModule.InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly InventoryRepository inventoryRepository;
        private readonly ItemInventoryRepository itemInventoryRepository;

        public InventoriesController(InventoryRepository inventoryRepository, ItemInventoryRepository itemInventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
            this.itemInventoryRepository = itemInventoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.inventoryRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await this.inventoryRepository.FindOne(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInventoryDto dto)
        {
            var result = await this.inventoryRepository.Create(new Data.Entities.Inventory
            {
                Name = dto.Name,
                UserId = dto.UserId,
            });

            return Created("", result);

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedInventoryDto dto)
        {
            await this.inventoryRepository.Update(new Data.Entities.Inventory
            {
                Id = dto.Id,
                Name = dto.Name,
                UserId = dto.UserId
            });

            return NoContent();
        }

        [HttpPost("AddItemToInventory")]
        public async Task<IActionResult> AddItemToInventory(AddItemToInventoryDto dto)
        {
            var result = await this.itemInventoryRepository.AddItemToInventory(new Data.Entities.ItemInventory
            {
                InventoryId = dto.InventoryId,
                ItemId = dto.ItemId
            });
            return Created("", result);
        }

        [HttpPost("RemoveItemFromInventory")]
        public async Task<IActionResult> RemoveItemFromInventory(AddItemToInventoryDto dto)
        {
            await this.itemInventoryRepository.RemoveItemFromInventory(new Data.Entities.ItemInventory
            {
                InventoryId = dto.InventoryId,
                ItemId = dto.ItemId
            });

            return NoContent();
        }

        [HttpGet("GetItemsFromInventory/{inventoryId}")]
        public async Task<IActionResult> GetItemsFromInventory(string inventoryId)
        {
            var result = await this.itemInventoryRepository.GetItems(inventoryId);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.inventoryRepository.Remove(id);
            return NoContent();
        }
    }
}