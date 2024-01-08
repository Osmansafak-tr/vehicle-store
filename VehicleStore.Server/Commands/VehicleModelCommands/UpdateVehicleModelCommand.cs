using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels;
using VehicleStore.Server.Services.ImageHandler;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class UpdateVehicleModelCommand
    {
        private readonly IAppDbContext _context;
        private readonly IImageHandler _imageHandler;

        public Guid Id { get; set; }
        public UpdateVehicleModelRequestModel Model { get; set; }

        public UpdateVehicleModelCommand(IAppDbContext context, IImageHandler imageHandler)
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

            var model = _context.VehicleModels.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new KeyNotFoundException("Vehicle Model Not Found");

            var sameModel = _context.VehicleModels.FirstOrDefault(x => x.Name == Model.Name && x.Id != Id);
            if (sameModel != null)
            {
                var errorMessage = new
                {
                    Name = "There is already a vehicle model with the same name"
                };
                var error = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(error);
            }

            model.Name = Model.Name;
            model.Type = Model.Type;
            model.Image = _imageHandler.ImageToByteArray(Model.Image);
            _context.SaveChanges();
        }
    }
}