using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Data.Entities;

namespace Weather.RA.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> GetByIdAsync(Guid id);

        Task<IEnumerable<Country>> GetAllAsync();

        Task<Country> CreateAsync(Country entity);

        Task UpdateAsync(Country entity);

        Task DeleteSoftlyAsync(Guid id);
    }
}
