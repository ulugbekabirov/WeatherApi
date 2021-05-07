using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Weather.Data.Entities;
using Weather.RA.DbContexts;
using Weather.RA.Interfaces;

namespace Weather.RA.MongoRepositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IMongoCollection<CityWeather> _collection;

        public WeatherRepository(IMongoDBContext context)
        {
            _collection = context.GetCollection<CityWeather>("WeatherAPI");
        }

        public async Task InsertRecortAsync(CityWeather cityWeather)
        {
            await _collection.InsertOneAsync(cityWeather);
        }
    }
}
