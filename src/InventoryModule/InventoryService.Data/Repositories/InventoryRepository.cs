using InventoryModule.InventoryService.Data.Entities;
using MongoDB.Driver;

namespace InventoryModule.InventoryService.Data.Repositories
{
    public class InventoryRepository
    {
        private readonly IMongoCollection<Inventory> inventoryCollection;

        public InventoryRepository()
        {
            var client = new MongoClient("mongodb://localhost:27018/");
            var database = client.GetDatabase("MikroserviceInventoryDb");
            inventoryCollection = database.GetCollection<Inventory>("inventories");
        }


        public async Task<List<Inventory>?> GetAll()
        {
            var filter = Builders<Inventory>.Filter.Empty;

            var result = await inventoryCollection.Find(filter).ToListAsync();

            return result;
        }

        public async Task<Inventory?> FindOne(string id)
        {
            var filter = Builders<Inventory>.Filter.Eq(x => x.Id, id);

            var result = await inventoryCollection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Inventory> Create(Inventory inventory)
        {
            await inventoryCollection.InsertOneAsync(inventory);
            return inventory;
        }

        public async Task Update(Inventory updatedInventory)
        {
            var filter = Builders<Inventory>.Filter.Eq(x => x.Id, updatedInventory.Id);

            // var updatedField = Builders<Inventory>.Update.Set(x => x.Name, updatedInventory.Name);
            // inventoryCollection.UpdateOne(filter, updatedField);

            await inventoryCollection.FindOneAndReplaceAsync(filter, updatedInventory);
        }

        public async Task Remove(string id)
        {
            var filter = Builders<Inventory>.Filter.Eq(x=>x.Id,id);
            await inventoryCollection.FindOneAndDeleteAsync(filter);
        }
    }
}