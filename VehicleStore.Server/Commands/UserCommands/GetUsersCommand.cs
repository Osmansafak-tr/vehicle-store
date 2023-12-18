using AutoMapper;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.ResponseModels.UserResponseModels;

namespace VehicleStore.Server.Commands.UserCommands
{
    public class GetUsersCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserResponseModel> Handle()
        {
            var users = _context.Users.ToList();
            return _mapper.Map<List<UserResponseModel>>(users);
        }
    }
}
