using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Weather.Data.Entities;

namespace Weather.RA.DbContexts
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _context;

        public MongoDBContext(string database)
        {
            var client = new MongoClient();
            _context = client.GetDatabase(database);
        }
    }
}
