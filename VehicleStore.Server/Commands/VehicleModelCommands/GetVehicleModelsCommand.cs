using AutoMapper;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.ResponseModels.VehicleModelResponseModels;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class GetVehicleModelsCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleModelsCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<VehicleModelResponseModel> Handle()
        {
            var models = _context.VehicleModels.ToList();
            if (models.Count == 0)
                return null;

            var vm = _mapper.Map<List<VehicleModelResponseModel>>(models);
            return vm;
        }
    }
}