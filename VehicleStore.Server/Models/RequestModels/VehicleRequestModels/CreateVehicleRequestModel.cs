namespace VehicleStore.Server.Models.RequestModels.VehicleRequestModels
{
    public class CreateVehicleRequestModel
    {
        public Guid ModelId { get; set; }
        public string Plate { get; set; }
        public Guid UserId { get; set; }
        public string Vin { get; set; }
    }
}