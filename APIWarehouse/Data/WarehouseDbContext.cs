using APIWarehouse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWarehouse.Data
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=warehouseapi;Trusted_Connection=True;");
        }
    }
}
