using AutoMapper;
using VehicleStore.Server.Common;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
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
            var models = _context.VehicleModels.ToList();
            var vmList = new List<VehicleResponseModel>();
            foreach (var vehicle in vehicles)
            {
                var model = models.Find(x => x.Id == vehicle.ModelId);
                var vmSrc = _mapper.Map<VehicleResponseModel>(vehicle);
                var vmDest = _mapper.Map<VehicleResponseModel>(model);
                ObjectMerger.Merge(vmSrc, vmDest);
                if (vmDest != null)
                    vmList.Add(vmDest);
            }

            return vmList;
        }
    }
}
