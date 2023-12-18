using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleStore.Server.Commands.VehicleCommands;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.VehicleRequestModels;

namespace VehicleStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class VehicleController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public VehicleController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            GetVehiclesCommand command = new GetVehiclesCommand(_context, _mapper);
            var cars = command.Handle();
            if (cars == null)
                return Ok("There are not any cars.");

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(Guid id)
        {
            var command = new GetVehicleByIdCommand(_context, _mapper);
            command.Id = id;
            var vm = command.Handle();
            return Ok(vm);
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] CreateVehicleRequestModel model)
        {
            var command = new CreateVehicleCommand(_context, _mapper)
            {
                Model = model
            };
            command.Handle();
            return Ok("Vehicle created.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(Guid id, [FromBody] UpdateVehicleRequestModel model)
        {
            var command = new UpdateVehicleCommand(_context, _mapper)
            {
                Id = id,
                Model = model
            };
            command.Handle();
            return Ok("Vehicle updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(Guid id)
        {
            var command = new DeleteVehicleCommand(_context)
            {
                Id = id
            };
            command.Handle();
            return Ok("Vehicle deleted.");
        }
    }
}
