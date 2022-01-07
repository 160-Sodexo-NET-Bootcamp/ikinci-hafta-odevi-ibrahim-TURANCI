using Data.Repository.ContainerRepo;
using Data.Repository.VehicleRepo;

namespace Data.UoW
{
    public interface IUnitOfWork
    {
        IVehicleRepo Vehicles { get; }
        IContainerRepo Containers { get; }

        int Complete();
    }
}
