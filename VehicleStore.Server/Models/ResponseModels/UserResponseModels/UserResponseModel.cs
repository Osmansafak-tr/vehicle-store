namespace VehicleStore.Server.Models.ResponseModels.UserResponseModels
{
    public class UserResponseModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Role { get; set; }
        public string CreatedAt { get; set; }
    }
}