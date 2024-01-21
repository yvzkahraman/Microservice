using System.Reflection;
using InventoryModule.InventoryService.API.Dtos;
using InventoryModule.InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryModule.InventoryService.API.Controllers
{
    public class InventoriesController : ControllerBase
    {
        private readonly InventoryRepository inventoryRepository;

        public InventoriesController(InventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.inventoryRepository.Remove(id);
            return NoContent();
        }
    }
}