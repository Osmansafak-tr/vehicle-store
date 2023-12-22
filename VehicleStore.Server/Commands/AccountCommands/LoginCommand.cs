using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.AccountRequestModels;
using VehicleStore.Server.Services.AuthTokenHandler;
using VehicleStore.Server.Services.PasswordHasher;

namespace VehicleStore.Server.Commands.AccountCommands
{
    public class LoginCommand
    {
        private readonly IAppDbContext _context;
        private readonly IAuthTokenHandler _tokenHandler;
        private readonly IPasswordHasher _passwordHasher = new PasswordHasher();
        public LoginRequestModel Model { get; set; } = null!;

        public LoginCommand(IAppDbContext context, IAuthTokenHandler tokenHandler)
        {
            _context = context;
            _tokenHandler = tokenHandler;
        }

        public string Handle()
        {
            if (Model == null)
                throw new Exception("LoginCommand model should be defined");

            var errorMessage = new ErrorMessage();
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
            if (user == null)
            {
                errorMessage.email = "Invalid Email. Please try again.";
                var errorJson = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(errorJson);
            }
            if (!_passwordHasher.Verify(user.Password, Model.Password))
            {
                errorMessage.password = "Invalid Password. Please try again.";
                var errorJson = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(errorJson);
            }
            var token = _tokenHandler.Generate(user.Id, user.Role.ToString());
            var json = new { token = token };
            return JsonConvert.SerializeObject(json);
        }

        private class ErrorMessage
        {
            public string email { get; set; } = "";
            public string password { get; set; } = "";
        }
    }
}