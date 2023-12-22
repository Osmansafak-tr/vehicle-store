using AutoMapper;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.ResponseModels.VehicleResponseModels;

namespace VehicleStore.Server.Commands.VehicleCommands
{
    public class GetVehicleByIdCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public Guid Id { get; set; }

        public GetVehicleByIdCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VehicleResponseModel Handle()
        {
            var vehicle = _context.Vehicles.SingleOrDefault(x => x.Id == Id) ?? throw new KeyNotFoundException("vehicle can not found.");
            var vm = _mapper.Map<VehicleResponseModel>(vehicle);
            return vm;
        }
    }
}