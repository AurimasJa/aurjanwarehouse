using APIWarehouse.Auth.Model;
using System.ComponentModel.DataAnnotations;

namespace APIWarehouse.Data.Models
{
    public class Warehouse : IUserOwnedResource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string UserId { get; set; }
        public WarehouseRestUser User { get; set; }





        //public Zone Zone { get; set; }
        //public Item Item { get; set; }


    }
}
