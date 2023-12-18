using System.ComponentModel.DataAnnotations;

namespace VehicleStore.Server.Models.Entities
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public VehicleModel VehicleModel { get; set; } = null!;
        public string Plate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Vin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
