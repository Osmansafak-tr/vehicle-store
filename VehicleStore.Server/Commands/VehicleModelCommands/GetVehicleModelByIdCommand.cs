using AutoMapper;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.ResponseModels.VehicleModelResponseModels;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class GetVehicleModelByIdCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public Guid Id { get; set; }

        public GetVehicleModelByIdCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public VehicleModelResponseModel Handle()
        {
            var model = _context.VehicleModels.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new KeyNotFoundException("Vehicle model not found.");

            var vm = _mapper.Map<VehicleModelResponseModel>(model);
            return vm;
        }
    }
}