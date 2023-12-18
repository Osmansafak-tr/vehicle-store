using Microsoft.EntityFrameworkCore;
using VehicleStore.Server.Models.Entities;

namespace VehicleStore.Server.Database
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        int SaveChanges();
    }
}