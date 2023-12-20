using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.AccountRequestModels;
using VehicleStore.Server.Services.AuthTokenHandler;

namespace VehicleStore.Server.Commands.AccountCommands
{
    public class LoginCommand
    {
        private readonly IAppDbContext _context;
        private readonly IAuthTokenHandler _tokenHandler;
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

            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email) ?? throw new KeyNotFoundException("User not found");
            var token = _tokenHandler.Generate(user.Id, user.Role.ToString());
            var json = new { token = token };
            return JsonConvert.SerializeObject(json);
        }
    }
}