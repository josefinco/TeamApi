using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TeamApi.Entities;
using TeamApi.Models;

namespace TeamApi.Services
{
    public class MongoDBService
    {


        private readonly IMongoCollection<Membro> _membrolistCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {

            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);

            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);

            _membrolistCollection = database.GetCollection<Membro>(mongoDBSettings.Value.CollectionName);

        }

        public async Task<List<Membro>?> GetAsync()
        {
            return await _membrolistCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Membro membro)
        {
            await _membrolistCollection.InsertOneAsync(membro);
            return;
        }

        public async Task AddToMembrosAsync(string id, string membroId)
        {
            FilterDefinition<Membro> filter = Builders<Membro>.Filter.Eq("Id", id);
            UpdateDefinition<Membro> update = Builders<Membro>.Update.AddToSet<string>("membroId", membroId);
            await _membrolistCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Membro> filter = Builders<Membro>.Filter.Eq("Id", id);
            await _membrolistCollection.DeleteOneAsync(filter);
            return;
        }

    }

}
