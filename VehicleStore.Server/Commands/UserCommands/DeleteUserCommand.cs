using VehicleStore.Server.Database;

namespace VehicleStore.Server.Commands.UserCommands
{
    public class DeleteUserCommand
    {
        private readonly IAppDbContext _context;
        public Guid Id { get; set; }

        public DeleteUserCommand(IAppDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id) ?? throw new KeyNotFoundException("User not found");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
