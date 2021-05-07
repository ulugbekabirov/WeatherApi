using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Weather.Data.Entities;
using Weather.ServiceHost.AppStart;

namespace Weather.RA.DbContexts
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _db;

        public MongoDBContext(IOptions<MongoSettings> configuration)
        {
            var client = new MongoClient(configuration.Value.Connection);
            _db = client.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> Collection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
