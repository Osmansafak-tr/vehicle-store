using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleStore.Server.Commands.UserCommands;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.UserRequestModels;

namespace VehicleStore.Server.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UserController(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var command = new GetUsersCommand(_context, _mapper);
            var users =  command.Handle();
            if (users.Count == 0)
                return Ok("There are no users right now.");
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var command = new GetUserByIdCommand(_context, _mapper)
            {
                Id= id
            };
            var user = command.Handle();
            return Ok(user);
        }

        [HttpPost] 
        public IActionResult CreateUser(CreateUserRequestModel model)
        {
            var command = new CreateUserCommand(_context, _mapper)
            {
                Model = model
            };
            command.Handle();
            return Ok("User created");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, UpdateUserRequestModel model)
        {
            var command = new UpdateUserCommand(_context)
            {
                Id = id,
                Model = model
            };
            command.Handle();
            return Ok("User updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var command = new DeleteUserCommand(_context)
            {
                Id = id
            };
            command.Handle();
            return Ok("User deleted");
        }
    }
}
