using Microsoft.EntityFrameworkCore;
using Weather.Data.Entities;

namespace Weather.RA.DbContexts
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base()
        {
            
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
