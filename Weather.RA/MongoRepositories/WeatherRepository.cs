using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Weather.Data.Entities;
using Weather.RA.DbContexts;

namespace Weather.RA.MongoRepositories
{
    public class WeatherRepository
    {
        private readonly IMongoCollection<CityWeather> _collection;

        public WeatherRepository(MongoDBContext context)
        {
            _collection = context.GetCollection<CityWeather>("WeatherAPI");
        }

        public async Task InsertRecortAsync(CityWeather cityWeather)
        {
            await _collection.InsertOneAsync(cityWeather);
        }
    }
}
