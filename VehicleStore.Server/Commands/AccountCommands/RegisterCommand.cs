using AutoMapper;
using Newtonsoft.Json;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Models.RequestModels.AccountRequestModels;

namespace VehicleStore.Server.Commands.AccountCommands
{
    public class RegisterCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public RegisterRequestModel Model { get; set; } = null!;

        public RegisterCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            if (Model == null)
                throw new Exception("Register model is not defined.");

            var sameUser = _context.Users.FirstOrDefault(x => x.Email == Model.Email);
            if (sameUser != null) 
                throw new InvalidOperationException(GetErrorMessage());
            var user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private string GetErrorMessage()
        {
            var error = new { email = "There is a user with same email" };
            return JsonConvert.SerializeObject(error);
        }
    }
}