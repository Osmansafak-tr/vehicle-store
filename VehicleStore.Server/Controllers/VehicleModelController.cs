using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleStore.Server.Commands.VehicleModelCommands;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;

namespace VehicleStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public VehicleModelController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetVehicleModels()
        {
            try
            {
                var command = new GetVehicleModelsCommand(_context, _mapper);
                var models = command.Handle();
                if (models == null)
                    return Ok("There aren't any vehicle view models.");

                return Ok(models);
            }
            catch (Exception exc)
            {
                return Problem(exc.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleModelById(Guid id)
        {
            var command = new GetVehicleModelByIdCommand(_context, _mapper)
            {
                Id = id
            };
            var model = command.Handle();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateVehicleModel([FromBody] CreateVehicleModelRequestModel model)
        {
            var command = new CreateVehicleModelCommand(_context, _mapper)
            {
                Model = model
            };
            command.Handle();

            return Ok("Vehicle model created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicleModel(Guid id, UpdateVehicleModelRequestModel model)
        {
            var command = new UpdateVehicleModelCommand(_context)
            {
                Id = id,
                Model = model,
            };
            command.Handle();
            return Ok("Vehicle model updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicleModel(Guid id)
        {
            var command = new DeleteVehicleModelCommand(_context)
            {
                Id = id
            };
            command.Handle();

            return Ok("Vehicle model deleted");
        }
    }
}
