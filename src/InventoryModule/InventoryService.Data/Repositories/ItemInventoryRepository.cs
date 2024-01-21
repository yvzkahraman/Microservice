using System.Security.Cryptography.X509Certificates;
using InventoryModule.InventoryService.Data.Entities;
using MongoDB.Driver;

namespace InventoryModule.InventoryService.Data.Repositories
{
    public class ItemInventoryRepository
    {
        private readonly IMongoCollection<ItemInventory> itemInventoryCollection;
        private readonly IMongoCollection<Item> itemCollection;

        public ItemInventoryRepository()
        {
            var client = new MongoClient("mongodb://localhost:27018/");
            var database = client.GetDatabase("MikroserviceInventoryDb");
            itemInventoryCollection = database.GetCollection<ItemInventory>("itemInventories");
            itemCollection = database.GetCollection<Item>("items");
        }

        // envarte hangi itemlar var.
        public async Task<List<Item>?> GetItems(string inventoryId)
        {
            var filter = Builders<ItemInventory>.Filter.Eq(x => x.InventoryId, inventoryId);
            var itemInventoryList = await itemInventoryCollection.Find(filter).ToListAsync();

            var itemIds = itemInventoryList.Select(x => x.ItemId).ToList();

            var filterII = Builders<Item>.Filter.In(x => x.Id, itemIds);

            var itemList = await itemCollection.Find(filterII).ToListAsync();

            return itemList;
        }



        // bir inventory'e bir item ekleme,
        // - stock kontrolü, eğer ürün varsa (update), stock 1 artırılacak
        // - eğer ürün yoksa, eklenecek.

        // sequence diagram.

        public async Task<ItemInventory> AddItemToInventory(ItemInventory itemInventory)
        {
            // var filterI = Builders<ItemInventory>.Filter.Eq(x => x.InventoryId, itemInventory.InventoryId);
            // var filterII = Builders<ItemInventory>.Filter.Eq(x => x.ItemId, itemInventory.ItemId);
            // var filter = Builders<ItemInventory>.Filter.And(filterI, filterII);


            var filter = Builders<ItemInventory>.Filter.And(
                        Builders<ItemInventory>.Filter.Eq(x => x.InventoryId, itemInventory.InventoryId),
                        Builders<ItemInventory>.Filter.Eq(x => x.ItemId, itemInventory.ItemId)
                    );

            var updatedItemInventory = await itemInventoryCollection.Find(filter).FirstOrDefaultAsync();

            if (updatedItemInventory == null)
            {
                itemInventory.Stock = 1;
                await itemInventoryCollection.InsertOneAsync(itemInventory);

                return itemInventory;

            }
            else
            {
                updatedItemInventory.Stock += 1;
                await itemInventoryCollection.FindOneAndReplaceAsync(filter, updatedItemInventory);

                return new ItemInventory
                {
                    Id = updatedItemInventory.Id,
                    InventoryId = updatedItemInventory.InventoryId,
                    ItemId = updatedItemInventory.ItemId,
                    Stock = updatedItemInventory.Stock,
                };
            }

        }



        // bir inventoriden bir item çıkarma 
        // ürün varmı ? 
        // stock 'u kaç edet, stock 1 den büyük update işlemi 1 ise remove işlemi

        public async Task RemoveItemFromInventory(ItemInventory itemInventory)
        {

            // && 
            var filter = Builders<ItemInventory>.Filter.And(
                Builders<ItemInventory>.Filter.Eq(x => x.InventoryId, itemInventory.InventoryId),
                Builders<ItemInventory>.Filter.Eq(x => x.ItemId, itemInventory.ItemId)
            );


            var updatedItemInventory = await itemInventoryCollection.Find(filter).FirstOrDefaultAsync();

            if (updatedItemInventory != null)
            {
                //update 
                if (updatedItemInventory.Stock > 1)
                {
                    updatedItemInventory.Stock -= 1;
                    await itemInventoryCollection.FindOneAndReplaceAsync(filter, updatedItemInventory);

                }
                //remove 
                else
                {
                    await itemInventoryCollection.FindOneAndDeleteAsync(filter);
                }

            }

        }
    }
}