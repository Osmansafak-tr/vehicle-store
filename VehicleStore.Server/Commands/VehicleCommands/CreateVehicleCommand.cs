using AutoMapper;
using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.VehicleRequestModels;

namespace VehicleStore.Server.Commands.VehicleCommands
{
    public class CreateVehicleCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateVehicleRequestModel Model;

        public CreateVehicleCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Plate == Model.Plate || x.Vin == Model.Vin);
            if (vehicle != null)
            {
                SameVehicleExistsException exceptionMessage = new();
                if (vehicle.Plate == Model.Plate)
                    exceptionMessage.Plate = "There is already a vehicle with same plate.";
                if (vehicle.Vin == Model.Vin)
                    exceptionMessage.Vin = "There is already a vehicle with same vin.";

                var message = JsonConvert.SerializeObject(exceptionMessage);
                throw new InvalidOperationException(message);
            }

            vehicle = _mapper.Map<Vehicle>(Model);
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
    }

    internal class SameVehicleExistsException
    {
        public string Plate { get; set; } = "";
        public string Vin { get; set; } = "";
    }
}