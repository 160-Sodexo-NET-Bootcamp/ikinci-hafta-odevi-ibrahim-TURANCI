using Data.Context;
using Data.DataModels;
using Data.Repository.GenericRepo;

namespace Data.Repository.VehicleRepo
{
    public class VehicleRepo : GenericRepo<Vehicle>, IVehicleRepo // GenericRepo classı ve IVehicle interfacini implemente eder.
    {
        public VehicleRepo(AppContext context) : base(context)
        {
           
        }

    }
}
