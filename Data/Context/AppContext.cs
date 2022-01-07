using Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Container> Container { get; set; }

        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
