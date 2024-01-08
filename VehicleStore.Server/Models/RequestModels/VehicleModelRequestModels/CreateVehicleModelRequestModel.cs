using VehicleStore.Server.Models.Entities;

namespace VehicleStore.Server.Models.RequestModels.VehicleModelRequestModels
{
    public class CreateVehicleModelRequestModel
    {
        public string Name { get; set; }
        public ModelType Type { get; set; }
        public IFormFile Image { get; set; }
    }
}