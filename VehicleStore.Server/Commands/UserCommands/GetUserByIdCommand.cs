using AutoMapper;
using VehicleStore.Server.Database;
using VehicleStore.Server.Models.ResponseModels.UserResponseModels;

namespace VehicleStore.Server.Commands.UserCommands
{
    public class GetUserByIdCommand
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public Guid Id { get; set; }

        public GetUserByIdCommand(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserResponseModel Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id) ?? throw new KeyNotFoundException("User not found");
            return _mapper.Map<UserResponseModel>(user);
        }
    }
}