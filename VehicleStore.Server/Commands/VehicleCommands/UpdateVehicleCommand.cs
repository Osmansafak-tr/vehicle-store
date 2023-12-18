using AutoMapper;
using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.VehicleRequestModels;

namespace VehicleStore.Server.Commands.VehicleCommands
{
    public class UpdateVehicleCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public Guid Id { get; set; }
        public UpdateVehicleRequestModel Model { get; set; }

        public UpdateVehicleCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            // Get vehicle by id
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == Id);
            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found.");

            // Check if there is a vehicle with the same plate or vehicleId
            var result = _context.Vehicles.FirstOrDefault(x => x.Plate == Model.Plate || x.Vin == Model.Vin);
            if (result != null)
            {
                SameVehicleExistsException exceptionMessage = new();
                if (result.Plate == Model.Plate)
                    exceptionMessage.Plate = "There is already a vehicle with same plate.";
                if (result.Vin == Model.Vin)
                    exceptionMessage.Vin = "There is already a vehicle with same vehicleId.";

                var message = JsonConvert.SerializeObject(exceptionMessage);
                throw new InvalidOperationException(message);
            }

            vehicle.ModelId = Model.ModelId != default ? Model.ModelId : vehicle.ModelId;
            vehicle.Plate = Model.Plate != default ? Model.Plate : vehicle.Plate;
            vehicle.UserId = Model.UserId != default ? Model.UserId : vehicle.UserId;
            vehicle.Vin = Model.Vin != default ? Model.Vin : vehicle.Vin;
            _context.SaveChanges();
        }
    }
}
