using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;
using VehicleStore.Server.Services.ImageHandler;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class CreateVehicleModelCommand
    {
        private readonly IAppDbContext _context;
        private readonly IImageHandler _imageHandler;

        public CreateVehicleModelRequestModel Model { get; set; }

        private readonly string[] validImageTypes = new string[] { "image/png", "image/jpg", "image/jpeg" };

        public CreateVehicleModelCommand(IAppDbContext context, IImageHandler imageHandler)
        {
            _context = context;
            _imageHandler = imageHandler;
        }

        public void Handle()
        {
            var isImageTypeValid = _imageHandler.CheckImageType(Model.Image.ContentType);
            if (!isImageTypeValid)
            {
                var error = new { Image = "Invalid image type" };
                var errorJson = JsonConvert.SerializeObject(error);
                throw new InvalidOperationException(errorJson);
            }

            var model = _context.VehicleModels.FirstOrDefault(x => x.Name == Model.Name);
            if (model != null)
            {
                var errorMessage = new { Name = "There is already a vehicle model with the same name." };
                var error = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(error);
            }

            var vehicleModel = new VehicleModel();
            vehicleModel.Name = Model.Name;
            vehicleModel.Type = Model.Type;
            vehicleModel.Image = _imageHandler.ImageToByteArray(Model.Image);
            _context.VehicleModels.Add(vehicleModel);
            _context.SaveChanges();
        }
    }
}