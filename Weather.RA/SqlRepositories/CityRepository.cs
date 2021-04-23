using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.RA.Interfaces;
using Weather.Data.Entities;
using Weather.RA.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Weather.RA.SqlRepositories
{
    public class CityRepository : ICityRepository
    {
        private readonly SqlContext _context;

        public CityRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(City entity)
        {
            await _context.Cities.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(City entity)
        {
            var city = await _context.Cities.FindAsync(entity.Id);
            city.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(City entity)
        {
            _context.Cities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
