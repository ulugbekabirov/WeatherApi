using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weather.Data.Entities;
using Weather.RA.DbContexts;
using Weather.RA.Interfaces;

namespace Weather.RA.SqlRepositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly SqlContext _context;

        public CountryRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Country entity)
        {
            await _context.Countries.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteSoftlyAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            country.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.Include(c => c.Cities).ToListAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries.Include(c => c.Cities).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Country entity)
        {
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
