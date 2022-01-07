using Data.DataModels;
using Data.UoW;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ibrahimTuranci_Odev2_GarbageCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allVehicles = await unitOfWork.Vehicles.GetAll();
            return Ok(allVehicles);

        } 
        [HttpGet]    //
        [Route("Containers")]
        public async Task<IActionResult> GetContainersOfVehicle([FromQuery]long Id)    
        {
            
            var allContainers = await unitOfWork.Containers.GetAll();
            return Ok(allContainers.Where(x => x.VehicleId == Id));
        }
        [HttpPost]
        public ActionResult<Vehicle> Post([FromBody] Vehicle request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            unitOfWork.Vehicles.Add(request);
            unitOfWork.Complete();
            return request;
        }
        [HttpPut]
        public ActionResult<Vehicle> Put([FromBody] Vehicle request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            unitOfWork.Vehicles.Update(request);
            unitOfWork.Complete();
            return request;
        }
        [HttpDelete("id")]
        public int Delete(int id)
        {


            unitOfWork.Vehicles.Delete(id);
            unitOfWork.Complete();
            return id;
        }
    }

}
