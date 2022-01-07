using Data.Context;
using Data.DataModels;
using Data.Repository.GenericRepo;

namespace Data.Repository.ContainerRepo
{
   public class ContainerRepo : GenericRepo<Container>, IContainerRepo //GenericReponun yaptığı herşeyi yapabilirim (T yerine Containerı kullan)
    {
        public ContainerRepo(AppContext context): base(context)
        {

        }
    }
}
