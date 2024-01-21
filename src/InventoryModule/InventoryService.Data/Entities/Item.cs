using MongoDB.Bson.Serialization.Attributes;

namespace InventoryModule.InventoryService.Data.Entities
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        //Range 0-10 
        public int Rarity { get; set; }
    }
}