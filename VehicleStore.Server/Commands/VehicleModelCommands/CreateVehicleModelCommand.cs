using AutoMapper;
using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class CreateVehicleModelCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateVehicleModelRequestModel Model { get; set; }

        public CreateVehicleModelCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var model = _context.VehicleModels.FirstOrDefault(x => x.Name == Model.Name);
            if (model != null)
            {
                var errorMessage = new ErrorMessage() { Name = "There is already a vehicle model with the same name." };
                var error = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(error);
            }

            var vehicleModel = _mapper.Map<VehicleModel>(Model);
            _context.VehicleModels.Add(vehicleModel);
            _context.SaveChanges();
        }
    }

    internal class ErrorMessage
    {
        public string Name;
    }
}
