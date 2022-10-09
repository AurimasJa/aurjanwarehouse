using APIWarehouse.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APIWarehouse.Data.Repositories
{
    public interface IZonesRepository
    {
        Task CreateAsync(Zone zone);
        Task DeleteAsync(Zone zone);
        Task<Zone?> GetAsync(int warehouseId, int zoneId);
        Task<IReadOnlyList<Zone>> GetManyAsync(int warehouseId);
        Task UpdateAsync(Zone zone);
    }

    public class ZonesRepository : IZonesRepository
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ZonesRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public async Task<Zone?> GetAsync(int warehouseId, int zoneId)
        {
            return await _warehouseDbContext.Zones.FirstOrDefaultAsync(x => x.Warehouse.Id == warehouseId && x.Id == zoneId);
        }

        public async Task<IReadOnlyList<Zone>> GetManyAsync(int warehouseId)
        {
            return await _warehouseDbContext.Zones.Where(x => x.Warehouse.Id == warehouseId).ToListAsync();
        }

        public async Task CreateAsync(Zone zone)
        {
            _warehouseDbContext.Zones.Add(zone);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Zone zone)
        {
            _warehouseDbContext.Zones.Update(zone);
            await _warehouseDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Zone zone)
        {
            _warehouseDbContext.Zones.Remove(zone);
            await _warehouseDbContext.SaveChangesAsync();
        }
    }
}
