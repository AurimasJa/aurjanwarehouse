namespace APIWarehouse.Data.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
