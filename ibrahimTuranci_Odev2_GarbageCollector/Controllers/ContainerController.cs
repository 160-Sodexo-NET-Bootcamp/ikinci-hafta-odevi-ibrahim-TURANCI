using Data.DataModels;
using Data.UoW;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ibrahimTuranci_Odev2_GarbageCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ContainerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allContainers = await unitOfWork.Containers.GetAll();
            return Ok(allContainers);
        }
        [HttpPost]
        public ActionResult<Container> Post([FromBody] Container request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            unitOfWork.Containers.Add(request);
            unitOfWork.Complete();
            return request;
        }
        [HttpPut]
        public ActionResult<Container> Put([FromBody] Container request)
        {
            if (request == null)
            {
                return BadRequest();
            }
           Container oldcontainer =  unitOfWork.Containers.Get(request.Id);
            unitOfWork.Containers.Detach(oldcontainer);
            if (oldcontainer.VehicleId != request.VehicleId)
            {
                return BadRequest("VehicleId Değiştirilemez");
            }

            unitOfWork.Containers.Update(request);
            unitOfWork.Complete();
            return request;
        }
        [HttpDelete("id")]
        public int Delete(int id)
        {


            unitOfWork.Containers.Delete(id);
            unitOfWork.Complete();
            return id;
        }
    }
}
