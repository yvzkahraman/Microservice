using MongoDB.Driver;
using UserModule.UserService.Data.Entities;
using UserModule.UserService.Data.Interfaces;

namespace UserModule.UserService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        IMongoCollection<AppUser> userCollection;
        public UserRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27018/");

            var database = mongoClient.GetDatabase("MikroserviceUserDb");
            userCollection = database.GetCollection<AppUser>("Users");
        }


        public async Task<AppUser> CreateAsync(AppUser user)
        {
            await userCollection.InsertOneAsync(user);
            return user;
        }


        public async Task UpdateAsync(AppUser user)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, user.Id);
            // var update = Builders<AppUser>.Update
            //     .Set(x => x.FirstName, user.FirstName);
            // userCollection.UpdateOne(filter, update);
            var result = await userCollection.FindOneAndReplaceAsync(filter, user);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, id);
            var result = await userCollection.DeleteOneAsync(filter);
        }

        public async Task<List<AppUser>?> GetList()
        {
            var filter = Builders<AppUser>.Filter.Empty;

            var result = await userCollection.Find(filter).ToListAsync();

            var resultII = await userCollection.Find(x => true).ToListAsync();


            return result;
        }

        public async Task<AppUser?> FindOne(string id)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, id);
            var result = await userCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

    }
}