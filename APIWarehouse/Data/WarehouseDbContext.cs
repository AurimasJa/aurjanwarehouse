using APIWarehouse.Auth.Model;
using APIWarehouse.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIWarehouse.Data
{
    public class WarehouseDbContext : IdentityDbContext<WarehouseRestUser>
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:warehouseapi.database.windows.net,1433;Initial Catalog=warehouseapi;Persist Security Info=False;User ID=admin1;Password=Adminas1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
