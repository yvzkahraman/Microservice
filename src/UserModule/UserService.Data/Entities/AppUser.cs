using MongoDB.Bson.Serialization.Attributes;

namespace UserModule.UserService.Data.Entities
{
    public class AppUser
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Username { get; set; } = null!;


        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Password { get; set; } = null!;


        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; } = null!;


        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; } = null!;

    }
}