using System.ComponentModel.DataAnnotations;

namespace VehicleStore.Server.Models.Entities
{
    public enum ModelType
    {
        Truck,
        Motor,
        Automobile,
    }

    public class VehicleModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public ModelType Type { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}