using VehicleStore.Server.Models.Entities;

namespace VehicleStore.Server.Models.RequestModels.AccountRequestModels
{
    public class RegisterRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserRole Role { get; set; }
    }
}