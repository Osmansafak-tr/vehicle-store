using VehicleStore.Server.Database;

namespace VehicleStore.Server.Commands.VehicleModelCommands
{
    public class DeleteVehicleModelCommand
    {
        private readonly IAppDbContext _context;
        public Guid Id { get; set; }

        public DeleteVehicleModelCommand(IAppDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var model = _context.VehicleModels.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                throw new KeyNotFoundException("Vehicle model not found");

            _context.VehicleModels.Remove(model);
            _context.SaveChanges();
        }
    }
}