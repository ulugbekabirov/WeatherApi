using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.RA.DbContexts;

namespace Weather.RA.MongoRepositories
{
    public class WeatherRepository
    {
        private readonly MongoDBContext _context;

        public WeatherRepository(MongoDBContext context)
        {
            _context = context;
        }

        public void InsertRecort<T>(string table, T record)
        {
            var collection = _context.Collection.InsertRecort<T>()
        }
    }
}
