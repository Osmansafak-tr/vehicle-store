using VehicleStore.Server.Models.Entities;

namespace VehicleStore.Server.Models.ResponseModels.VehicleModelResponseModels
{
    public class VehicleModelResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ModelType Type { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}