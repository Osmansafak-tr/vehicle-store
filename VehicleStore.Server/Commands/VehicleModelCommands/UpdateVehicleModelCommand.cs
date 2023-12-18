using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class UpdateVehicleModelCommand
    {
        private readonly IAppDbContext _context;

        public Guid Id { get; set; }
        public UpdateVehicleModelRequestModel Model { get; set; }

        public UpdateVehicleModelCommand(IAppDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var model = _context.VehicleModels.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new KeyNotFoundException("Vehicle Model Not Found");

            var sameModel = _context.VehicleModels.FirstOrDefault(x => x.Name == Model.Name);
            if (sameModel != null)
            {
                var errorMessage = new ErrorMessage()
                {
                    Name = "There is already a vehicle model with the same name"
                };
                var error = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(error);
            }

            model.Name = Model.Name;
            model.Type = Model.Type;
            model.ImageUrl = Model.ImageUrl;
            _context.SaveChanges();
        }
    }
}
