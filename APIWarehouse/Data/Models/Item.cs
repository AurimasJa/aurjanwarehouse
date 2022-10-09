namespace APIWarehouse.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
    }
}
