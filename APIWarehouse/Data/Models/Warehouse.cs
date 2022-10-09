namespace APIWarehouse.Data.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }

        public Warehouse(int id, string name, string description, string address, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Address = address;
            CreationDate = creationDate;
        }

        public Warehouse(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Warehouse()
        {
        }


        //public Zone Zone { get; set; }
        //public Item Item { get; set; }


    }
}
