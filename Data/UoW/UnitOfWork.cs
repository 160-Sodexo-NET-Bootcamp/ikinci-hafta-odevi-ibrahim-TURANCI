using Data.Context;
using Data.Repository.ContainerRepo;
using Data.Repository.VehicleRepo;

namespace Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;
        public IVehicleRepo Vehicles { get; private set; }
        public IContainerRepo Containers { get; private set; }

        

        public UnitOfWork(AppContext context)
        {
            this._context = context;
            Vehicles = new VehicleRepo(_context);
            Containers = new ContainerRepo(_context);
           
        }

        public int Complete()
        {
            return _context.SaveChanges();
        } 

    }
}
