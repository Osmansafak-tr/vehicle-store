using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleStore.Server.Commands.VehicleModelCommands;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;
using VehicleStore.Server.Services.ImageHandler;

namespace VehicleStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageHandler _imageHandler;

        public VehicleModelController(IAppDbContext context, IMapper mapper, IImageHandler imageHandler)
        {
            _context = context;
            _mapper = mapper;
            _imageHandler = imageHandler;
        }

        [HttpGet]
        public IActionResult GetVehicleModels()
        {
            var command = new GetVehicleModelsCommand(_context, _mapper);
            var models = command.Handle();
            if (models == null)
                return Ok("There aren't any vehicle view models.");

            return Ok(models);
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
        public IActionResult CreateVehicleModel([FromForm] CreateVehicleModelRequestModel model)
        {
            var command = new CreateVehicleModelCommand(_context, _imageHandler)
            {
                Model = model
            };
            command.Handle();

            return Ok("Vehicle model created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicleModel(Guid id, [FromForm] UpdateVehicleModelRequestModel model)
        {
            var command = new UpdateVehicleModelCommand(_context, _imageHandler)
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