using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weather.Data.Entities;
using Weather.RA.DbContexts;
using Weather.RA.Interfaces;

namespace Weather.RA.SqlRepositories
{
    public class CityRepository : ICityRepository
    {
        private readonly SqlContext _context;

        public CityRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<City> CreateAsync(City entity)
        {
            var city = await _context.Cities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return city.Entity;
        }

        public async Task DeleteSoftlyAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            city.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task UpdateAsync(City entity)
        {
            _context.Cities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
