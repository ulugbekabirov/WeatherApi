using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Country> CreateAsync(Country entity)
        {
            var country = await _context.Countries.AddAsync(entity);
            await _context.SaveChangesAsync();
            return country.Entity;
        }

        public async Task DeleteSoftlyAsync(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);
            country.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _context.Countries.Where(c => !c.IsDeleted).Include(c => c.Cities).ToListAsync();
        }

        public async Task<Country> GetByIdAsync(Guid id)
        {
            return await _context.Countries.Include(c => c.Cities).FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task UpdateAsync(Country entity)
        {
            entity.Version++;
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
