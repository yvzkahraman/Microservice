
using InventoryModule.InventoryService.Data.Repositories;
using MassTransit;
using Newtonsoft.Json;
using SharedModule.Shared.Interfaces;

namespace InventoryModule.InventoryService.API.Consumers
{
    public class MarketCreatedConsumer : IConsumer<MarketCreated>
    {
        public async Task Consume(ConsumeContext<MarketCreated> context)
        {
            var message = context.Message;

            // JsonConvert.DeserializeObject(message);


            var itemInventoryRepository = new ItemInventoryRepository();
            await itemInventoryRepository.RemoveItemFromInventory(new Data.Entities.ItemInventory
            {
                InventoryId = message.InventoryId,
                ItemId = message.ItemId
            });
            Console.WriteLine("Gelen message :" + message.InventoryId);
        }
    }

}