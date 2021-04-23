using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Data.Entities;
using Weather.RA.Interfaces;

namespace Weather.RA.SqlRepositories
{
    public class CountryRepository : ICountryRepository
    {
        public Task<Country> CreateAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
