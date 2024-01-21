using InventoryModule.InventoryService.Data.Entities;
using MongoDB.Driver;

namespace InventoryModule.InventoryService.Data.Repositories
{

    public class ItemRepository
    {
        private readonly IMongoCollection<Item> itemCollection;
        public ItemRepository()
        {
            var client = new MongoClient("mongodb://localhost:27018/");
            var database = client.GetDatabase("MikroserviceInventoryDb");
            itemCollection = database.GetCollection<Item>("items");
        }

        public async Task<List<Item>?> GetAll()
        {
            var filter = Builders<Item>.Filter.Empty;
            var result = await itemCollection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<Item> Get(string id)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);

            var result = await itemCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Item> Create(Item item)
        {
            await itemCollection.InsertOneAsync(item);

            return item;
        }


        public async Task Update(Item updatedItem)
        {

            var filter = Builders<Item>.Filter.Eq(x => x.Id, updatedItem.Id);

            await itemCollection.FindOneAndReplaceAsync(filter, updatedItem);
        }


        public async Task Remove(string id)
        {
            var filter = Builders<Item>.Filter.Eq(x => x.Id, id);
            await itemCollection.DeleteOneAsync(filter);
        }
    }

}