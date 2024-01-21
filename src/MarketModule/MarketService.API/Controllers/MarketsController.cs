using System.Text;
using System.Text.Json;
using MarketModule.MarketService.API.Dtos;
using MarketModule.MarketService.Data.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedModule.Shared.Interfaces;

namespace MarketModule.MarketService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        private readonly MarketRepository marketRepository;
        private readonly IHttpClientFactory httpClientFactory;

        private readonly IPublishEndpoint publishEndpoint;

        public MarketsController(MarketRepository marketRepository, IHttpClientFactory httpClientFactory, IPublishEndpoint publishEndpoint)
        {
            this.marketRepository = marketRepository;
            this.httpClientFactory = httpClientFactory;
            this.publishEndpoint = publishEndpoint;
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


            // var postData = new { dto.InventoryId, dto.ItemId };

            // var jsonData = JsonSerializer.Serialize(postData, new JsonSerializerOptions
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //     WriteIndented = true
            // });

            // var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // var client = this.httpClientFactory.CreateClient();
            // var response = await client.PostAsync("http://localhost:5010/api/Inventories/RemoveItemFromInventory", stringContent);

            //  if (response.IsSuccessStatusCode)
            // {
            //       }

            // return BadRequest("Ürün envanterden düşmediği için, markete eklenemedi");

            await this.publishEndpoint.Publish<MarketCreated>(new
            {

                dto.InventoryId,
                dto.ItemId
            });



            var result = await marketRepository.Create(new Data.Entities.Market
            {
                ItemId = dto.ItemId,
                Price = dto.Price,
                SellerId = dto.SellerId
            });

            return Created("", result);





        }
    }

}



