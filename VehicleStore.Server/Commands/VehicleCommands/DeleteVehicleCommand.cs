using VehicleStore.Server.Database;

namespace VehicleStore.Server.Commands.VehicleCommands
{
    public class DeleteVehicleCommand
    {
        private readonly IAppDbContext _context;
        public Guid Id { get; set; }

        public DeleteVehicleCommand(IAppDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == Id);
            if (vehicle == null)
                throw new KeyNotFoundException("Vehicle not found.");

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }
    }
}