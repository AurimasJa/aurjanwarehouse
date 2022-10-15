using APIWarehouse.Data.Dtos;
using APIWarehouse.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using APIWarehouse.Data.Models;

namespace APIWarehouse.Controllers;

[ApiController]
[Route("api/warehouses/{warehouseId}/zones")]
public class ZonesController : ControllerBase
{
    private readonly IZonesRepository _zoneRepository;
    private readonly IMapper _mapper;
    private readonly IWarehousesRepository _warehousesRepository;

    public ZonesController(IZonesRepository zoneRepository, IMapper mapper, IWarehousesRepository warehousesRepository)
    {
        _zoneRepository = zoneRepository;
        _mapper = mapper;
        _warehousesRepository = warehousesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<ZoneDto>> GetAllAsync(int warehouseId)
    {
        var zones = await _zoneRepository.GetManyAsync(warehouseId);
        return zones.Select(x => _mapper.Map<ZoneDto>(x));
    }

    [HttpGet]
    [Route("{zoneId}")]
    public async Task<ActionResult<ZoneDto>> GetOne(int warehouseId, int zoneId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);
        if (warehouse == null) return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
        var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
        if (zone == null)
            return NotFound($"Zone {zoneId}id does not exist");

        if (zone == null)
        {
            return NotFound($"Zone {zoneId}id does not exist");
        }

        return Ok(_mapper.Map<ZoneDto>(zone));
    }
    [HttpPost]
    public async Task<ActionResult<ZoneDto>> Create(int warehouseId, ZoneDto zoneDto)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);
        if (warehouse == null) return NotFound($"Couldn't find a warehouse with id of {warehouseId}");

        if (zoneDto.Name is not null && zoneDto.Name.All(char.IsDigit))
        {
            return BadRequest("You need to put valid name");
        }
        else
        {
            var zone = _mapper.Map<Zone>(zoneDto);
            zone.WarehouseId = warehouseId;

            await _zoneRepository.CreateAsync(zone);

            return Created($"/api/topics/{warehouseId}/posts/{zone.Id}", _mapper.Map<ZoneDto>(zone));
        }
    }

    [HttpPut("{zoneId}")]
    public async Task<ActionResult<ZoneDto>> Update(int warehouseId, int zoneId, UpdateZoneDto zoneDto)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);
        if (warehouse == null) return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
        var oldZone = await _zoneRepository.GetAsync(warehouseId, zoneId);
        if (oldZone == null)
            return NotFound($"Zone {zoneId}id does not exist");
        if (zoneDto.Name is not null && zoneDto.Name.All(char.IsDigit))
        {
            return BadRequest("You need to put valid name");
        }
        else
        {
            oldZone.Name = zoneDto.Name is null ? oldZone.Name : zoneDto.Name;
            await _zoneRepository.UpdateAsync(oldZone);

            return Ok(_mapper.Map<ZoneDto>(oldZone));
        }
    }

    [HttpDelete("{zoneId}")]
    public async Task<ActionResult> Remove(int warehouseId, int zoneId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);
        if (warehouse == null) return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
        var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
        if (zone == null)
            return NotFound($"Zone {zoneId}id does not exist");
        await _zoneRepository.DeleteAsync(zone);

        // 204
        return NoContent();
    }


}

