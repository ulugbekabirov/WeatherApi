using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
using Weather.RA.Interfaces;
using Weather.Data.Entities;

namespace Weather.RA.SqlRepositories
{
    public class CityRepository : ICityRepository
    {
        public Task<City> CreateAsync(City entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(City entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(City entity)
        {
            throw new NotImplementedException();
        }
    }
}
