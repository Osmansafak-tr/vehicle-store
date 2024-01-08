using VehicleStore.Server.Models.Entities;

namespace VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels
{
    public class UpdateVehicleModelRequestModel
    {
        public string Name { get; set; }
        public ModelType Type { get; set; }
        public IFormFile Image { get; set; }
    }
}