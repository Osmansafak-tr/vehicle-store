namespace VehicleStore.Server.Models.ResponseModels.VehicleResponseModels
{
    public class VehicleResponseModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        public string Plate { get; set; }
        public Guid UserId { get; set; }
    }
}