namespace VehicleStore.Server.Models.Entities
{
    public enum UserRole
    {
        User,
        Admin
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
