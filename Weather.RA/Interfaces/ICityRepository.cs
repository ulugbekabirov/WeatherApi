using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Data.Entities;

namespace Weather.RA.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetByIdAsync(int id);

        Task<IEnumerable<City>> GetAllAsync();

        Task<City> CreateAsync(City entity);

        Task UpdateAsync(City entity);

        Task DeleteSoftlyAsync(int id);
    }
}
