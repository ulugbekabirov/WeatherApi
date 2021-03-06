using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Weather.RA.Interfaces;

namespace Weather.RA.DbContexts
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _db;

        public MongoDBContext(IOptions<MongoSettings> configuration)
        {
            var client = new MongoClient(configuration.Value.Connection);
            _db = client.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
