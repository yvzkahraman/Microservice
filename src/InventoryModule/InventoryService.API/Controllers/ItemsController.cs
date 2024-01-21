using InventoryModule.InventoryService.API.Dtos;
using InventoryModule.InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryModule.InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository itemRepository;

        public ItemsController(ItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemDto dto)
        {
            var result = await itemRepository.Create(new Data.Entities.Item
            {
                Name = dto.Name,
                Rarity = dto.Rarity,
            });

            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await itemRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await itemRepository.Get(id);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateItemDto dto)
        {
            await itemRepository.Update(new Data.Entities.Item
            {
                Id = dto.Id,
                Name = dto.Name,
                Rarity = dto.Rarity
            });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await itemRepository.Remove(id);

            return NoContent();
        }
    }
}