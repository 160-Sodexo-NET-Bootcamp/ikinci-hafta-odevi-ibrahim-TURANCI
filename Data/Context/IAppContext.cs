using Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public interface IAppContext 
    {
        DbSet<Container> Container { get; set; }
        DbSet<Vehicle> Vehicle { get; set; }
    }
}
