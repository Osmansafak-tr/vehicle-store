using Microsoft.AspNetCore.Mvc;
using VehicleStore.Server.Commands.AccountCommands;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.AccountRequestModels;
using VehicleStore.Server.Services.AuthTokenHandler;

namespace VehicleStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IAuthTokenHandler _tokenHandler;

        public AccountController(IAppDbContext context, IAuthTokenHandler tokenHandler)
        {
            _context = context;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequestModel model)
        {
            var command = new LoginCommand(_context, _tokenHandler)
            {
                Model = model
            };
            var token = command.Handle();
            return Ok(token);
        }
    }
}