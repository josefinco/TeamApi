using Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TeamApi.Models;

namespace Domain.Services
{
    public class UsuarioService
    {

        private readonly IMongoCollection<Usuario> _usuariolistCollection;

        public UsuarioService(IOptions<MongoDBSettings> mongoDBSettings)
        {

            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);

            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);

            _usuariolistCollection = database.GetCollection<Usuario>(mongoDBSettings.Value.CollectionName);

        }




        public async Task<Usuario>? GetAsync(string usuario)
        {
            List<Usuario> users = await _usuariolistCollection.Find(new BsonDocument()).ToListAsync();

            if (users == null) return null;

            return users.AsQueryable<Usuario>().Where(c => c.Username == usuario).FirstOrDefault();
        }


        public async Task CreateAsync(Usuario usuario)
        {
            await _usuariolistCollection.InsertOneAsync(usuario);
            return;
        }        
    }
}
