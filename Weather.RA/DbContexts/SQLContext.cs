using Microsoft.EntityFrameworkCore;
using Weather.Data.Entities;

namespace Weather.RA.DbContexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.AlphaCode).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => c.Name).IsUnique();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
