using Microsoft.EntityFrameworkCore;
using VehicleStore.Server.Models.Entities;
using VehicleStore.Server.Services.PasswordHasher;

namespace VehicleStore.Server.Database
{
    public class SeedData
    {
        private static readonly IPasswordHasher _passwordHasher = new PasswordHasher();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Vehicles.Any())
                    return;

                var guid_user = Guid.NewGuid();
                context.Users.AddRange(
                    new User()
                    {
                        Id = guid_user,
                        Email = "admin@gmail.com",
                        Password = _passwordHasher.Hash("12345"),
                        Role = UserRole.Admin,
                    },
                    new User()
                    {
                        Email = "user@gmail.com",
                        Password = _passwordHasher.Hash("12345"),
                        Role = UserRole.User,
                    }
                );

                Guid guid_model = Guid.NewGuid();
                Guid guid_model2 = Guid.NewGuid();
                context.VehicleModels.AddRange(
                    new VehicleModel()
                    {
                        Id = guid_model,
                        Name = "Test Model 1",
                        Type = ModelType.Automobile,
                        Image = new byte[64],
                    },
                    new VehicleModel()
                    {
                        Id = guid_model2,
                        Name = "Test Model 2",
                        Type = ModelType.Automobile,
                        Image = new byte[64],
                    }
                );

                context.Vehicles.AddRange(
                    new Vehicle()
                    {
                        ModelId = guid_model,
                        UserId = guid_user,
                        Plate = "11 AAA 11",
                        Vin = "111111111"
                    },
                    new Vehicle()
                    {
                        ModelId = guid_model2,
                        UserId = guid_user,
                        Plate = "22 AAA 22",
                        Vin = "111111112"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}