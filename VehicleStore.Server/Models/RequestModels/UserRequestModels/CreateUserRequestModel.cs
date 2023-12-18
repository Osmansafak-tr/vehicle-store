using VehicleStore.Server.Models.Entities;

namespace VehicleStore.Server.Models.RequestModels.UserRequestModels
{
    public class CreateUserRequestModel
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public UserRole Role { get; set; }
    }
}