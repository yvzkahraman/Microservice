using System.Text;
using System.Text.Json;
using MarketModule.MarketService.API.Dtos;
using MarketModule.MarketService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketModule.MarketService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        private readonly MarketRepository marketRepository;
        private readonly IHttpClientFactory httpClientFactory;

        public MarketsController(MarketRepository marketRepository, IHttpClientFactory httpClientFactory)
        {
            this.marketRepository = marketRepository;
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await this.marketRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MarketCreateDto dto)
        {


            var postData = new { dto.InventoryId, dto.ItemId };

            var jsonData = JsonSerializer.Serialize(postData, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var client = this.httpClientFactory.CreateClient();
            var response = await client.PostAsync("http://localhost:5010/api/Inventories/RemoveItemFromInventory", stringContent);


            if (response.IsSuccessStatusCode)
            {
                var result = await marketRepository.Create(new Data.Entities.Market
                {
                    ItemId = dto.ItemId,
                    Price = dto.Price,
                    SellerId = dto.SellerId
                });

                return Created("", result);

            }

            return BadRequest("Ürün envanterden düşmediği için, markete eklenemedi");



        }
    }

}



