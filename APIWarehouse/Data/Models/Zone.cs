using APIWarehouse.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace APIWarehouse.Data.Models
{
    public class Zone : IUserOwnedResource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        [Required]
        public string UserId { get; set; }
        public WarehouseRestUser User { get; set; }
    }
}
