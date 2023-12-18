using AutoMapper;
using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.RequestModels.UserRequestModels;

namespace VehicleStore.Server.Commands.UserCommands
{
    public class UpdateUserCommand
    {
        private readonly IAppDbContext _context;

        public Guid Id { get; set; }
        public UpdateUserRequestModel Model { get; set; } = null!;

        public UpdateUserCommand(IAppDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id) ?? throw new KeyNotFoundException("User not found");

            var sameUser = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Id != Id);
            if (sameUser != null)
            {
                var errorMessage = new ErrorMessage
                {
                    Email = "This email already in use."
                };
                var errorJson = JsonConvert.SerializeObject(errorMessage);
                throw new InvalidOperationException(errorJson);
            }

            user.Email = Model.Email;
            user.Password = Model.Password;
            user.Name = Model.Name != default ? Model.Name : user.Name;
            user.Surname = Model.Surname != default ? Model.Surname : user.Surname;
            user.Role = Model.Role;
            _context.SaveChanges();
        }

        private class ErrorMessage
        {
            public string Email { get; set; } = "";
        }
    }
}
