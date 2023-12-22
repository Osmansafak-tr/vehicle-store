using AutoMapper;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.ResponseModels.VehicleResponseModels;

namespace VehicleStore.Server.Commands.VehicleCommands
{
    public class GetVehiclesCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetVehiclesCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<VehicleResponseModel> Handle()
        {
            var vehicles = _context.Vehicles.ToList();
            if (vehicles.Count == 0)
                return null;

            return _mapper.Map<List<VehicleResponseModel>>(vehicles);
        }
    }
}