using APIWarehouse.Data.Dtos;
using APIWarehouse.Data.Models;
using APIWarehouse.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWarehouse.Controllers
{
    [ApiController]
    [Route("api/warehouses/{warehouseId}/zones/{zoneId}/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IZonesRepository _zoneRepository;
        private readonly IMapper _mapper;
        private readonly IWarehousesRepository _warehousesRepository;
        private readonly IItemsRepository _itemsRepository;

        public ItemsController(IZonesRepository zoneRepository, IMapper mapper, IWarehousesRepository warehousesRepository, IItemsRepository itemsRepository)
        {
            _zoneRepository = zoneRepository;
            _mapper = mapper;
            _warehousesRepository = warehousesRepository;
            _itemsRepository = itemsRepository;
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<ActionResult<ZoneDto>> GetOne(int warehouseId, int zoneId, int itemId)
        {
            var warehouse = await _warehousesRepository.GetAsync(warehouseId);
            if (warehouse == null)
            { 
                return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
            }
            var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
            if (zone == null)
            {
                return NotFound($"Zone {zoneId}id does not exist");
            }
            var item = await _itemsRepository.GetAsync(warehouseId, zoneId, itemId);
            if (item == null)
            {
                return NotFound($"Item {itemId}id does not exist");
            }
            return Ok(_mapper.Map<ItemDto>(item));
        }
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAllAsync(int warehouseId, int zoneId)
        {
            var items = await _itemsRepository.GetManyAsync(warehouseId, zoneId);
            return items.Select(x => _mapper.Map<ItemDto>(x));
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> Create(int warehouseId, int zoneId, ItemDto itemDto)
        {
            var warehouse = await _warehousesRepository.GetAsync(warehouseId);
            if (warehouse == null)
            {
                return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
            }
            var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
            if (zone == null)
            {
                return NotFound($"Zone {zoneId}id does not exist");
            }

            if (itemDto.Name is not null && itemDto.Name.All(char.IsDigit) || itemDto.Name is null)
            {
                return BadRequest("You need to put valid name/description");
            }
            if (itemDto.Description is not null && itemDto.Description.All(char.IsDigit) || itemDto.Description is null)
            {
                return BadRequest("You need to put valid name/description");
            }
            else
            {
                var item = _mapper.Map<Item>(itemDto);
                item.ZoneId = zoneId;

                await _itemsRepository.CreateAsync(item);

                return Created($"/api/topics/{warehouseId}/posts/{zoneId}/items/{item.Id}", _mapper.Map<ItemDto>(item));

            }
        }
        [HttpPut("{itemId}")]
        public async Task<ActionResult<ItemDto>> Update(int warehouseId, int zoneId, int itemId, UpdateItemDto itemDto)
        {
            var warehouse = await _warehousesRepository.GetAsync(warehouseId);
            if (warehouse == null)
            {
                return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
            }
            var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
            if (zone == null)
            {
                return NotFound($"Zone {zoneId}id does not exist");
            }
            var oldItem = await _itemsRepository.GetAsync(warehouseId, zoneId, itemId);
            if (oldItem == null)
            {
                return NotFound($"Item {itemId}id does not exist");
            }

            if (itemDto.Name is not null && itemDto.Name.All(char.IsDigit))
            {
                return BadRequest("You need to put valid name/description");
            }
            if (itemDto.Description is not null && itemDto.Description.All(char.IsDigit))
            {
                return BadRequest("You need to put valid name/description");
            }
            else
            {
                //_mapper.Map(itemDto, oldItem);
                oldItem.Name = itemDto.Name is null ? oldItem.Name : itemDto.Name;
                oldItem.Description = itemDto.Description is null ? oldItem.Description : itemDto.Description;
                await _itemsRepository.UpdateAsync(oldItem);

                return Ok(_mapper.Map<ItemDto>(oldItem));

            }
        }
        [HttpDelete("{itemId}")]
        public async Task<ActionResult> Remove(int warehouseId, int zoneId, int itemId)
        {
            var warehouse = await _warehousesRepository.GetAsync(warehouseId);
            if (warehouse == null)
            {
                return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
            }
            var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
            if (zone == null)
            {
                return NotFound($"Zone {zoneId}id does not exist");
            }
            var item = await _itemsRepository.GetAsync(warehouseId, zoneId, itemId);
            if (item == null)
            {
                return NotFound($"Item {itemId}id does not exist");
            }
            await _itemsRepository.DeleteAsync(item);

            // 204
            return NoContent();
        }
    }
}
