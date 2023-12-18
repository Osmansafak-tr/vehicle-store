using AutoMapper;
using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.UserRequestModels;

namespace VehicleStore.Server.Commands.UserCommands
{
    public class CreateUserCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserRequestModel Model { get; set; } = null!;

        public CreateUserCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var sameUser = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
            if (sameUser != null)
            {
                var errorMessage = new ErrorMessage
                {
                    Email = "This email already in use."
                };
                var errorJson = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(errorJson);
            }

            var user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private class ErrorMessage
        {
            public string Email { get; set; } = "";
        }
    }
}
