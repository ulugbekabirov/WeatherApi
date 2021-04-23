using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
