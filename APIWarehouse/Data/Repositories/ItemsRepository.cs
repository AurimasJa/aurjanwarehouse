using APIWarehouse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWarehouse.Data.Repositories
{
    public interface IItemsRepository
    {
        Task CreateAsync(Item item);
        Task DeleteAsync(Item item);
        Task<Item?> GetAsync(int warehouseId, int zoneId, int itemId);
        Task<IReadOnlyList<Item>> GetManyAsync(int warehouseId, int zoneId);
        Task UpdateAsync(Item item);
    }

    public class ItemsRepository : IItemsRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ItemsRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public async Task<Item?> GetAsync(int warehouseId, int zoneId, int itemId)
        {
            return await _warehouseDbContext.Items.FirstOrDefaultAsync(x => x.Zone.Warehouse.Id == warehouseId && x.Zone.Id == zoneId && x.Id == itemId);
        }

        public async Task<IReadOnlyList<Item>> GetManyAsync(int warehouseId, int zoneId)
        {
            return await _warehouseDbContext.Items.Where(x => x.Zone.Warehouse.Id == warehouseId && x.Zone.Id == zoneId).ToListAsync();
        }

        public async Task CreateAsync(Item item)
        {
            _warehouseDbContext.Items.Add(item);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _warehouseDbContext.Items.Update(item);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Item item)
        {
            _warehouseDbContext.Items.Remove(item);
            await _warehouseDbContext.SaveChangesAsync();
        }
    }
}
