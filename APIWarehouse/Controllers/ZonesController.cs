using APIWarehouse.Data.Dtos;
using APIWarehouse.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using APIWarehouse.Data.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using APIWarehouse.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace APIWarehouse.Controllers;

[ApiController]
[Route("api/warehouses/{warehouseId}/zones")]
public class ZonesController : ControllerBase
{
    private readonly IZonesRepository _zoneRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly IWarehousesRepository _warehousesRepository;

    public ZonesController(IZonesRepository zoneRepository, IMapper mapper, IAuthorizationService authorizationService, IWarehousesRepository warehousesRepository)
    {
        _zoneRepository = zoneRepository;
        _authorizationService = authorizationService;
        _mapper = mapper;
        _warehousesRepository = warehousesRepository;
    }

    [HttpGet]
    [Authorize(Roles = WarehouseRoles.Admin + "," + WarehouseRoles.Manager + "," + WarehouseRoles.Worker)]
    public async Task<IEnumerable<ZoneDto>> GetAllAsync(int warehouseId)
    {
        var zones = await _zoneRepository.GetManyAsync(warehouseId); 
        //var authorizationResult = await _authorizationService.AuthorizeAsync(User, zones, PolicyNames.ResourceOwner);
        //if (!authorizationResult.Succeeded)
        //{
        //    return (IEnumerable<ZoneDto>)Forbid();
        //}
        return zones.Select(x => _mapper.Map<ZoneDto>(x));
    }

    [HttpGet]
    [Route("{zoneId}")]
    [Authorize(Roles = WarehouseRoles.Admin + "," + WarehouseRoles.Manager + "," + WarehouseRoles.Worker)]
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
        //var authorizationResult = await _authorizationService.AuthorizeAsync(User, warehouse, PolicyNames.ResourceOwner);
        //if (!authorizationResult.Succeeded)
        //{
        //    return Forbid();
        //}
        return Ok(_mapper.Map<ZoneDto>(zone));
    }
    [HttpPost]
    [Authorize(Roles = WarehouseRoles.Admin +", " + WarehouseRoles.Manager)]
    public async Task<ActionResult<ZoneDto>> Create(int warehouseId, ZoneDto zoneDto)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);
        if (warehouse == null) return NotFound($"Couldn't find a warehouse with id of {warehouseId}");

        if (zoneDto.Name is not null && zoneDto.Name.All(char.IsDigit) || zoneDto.Name is null)
        {
            return BadRequest("You need to put valid name");
        }
        else
        {
            var zone = _mapper.Map<Zone>(zoneDto);
            zone.UserId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
               
            zone.WarehouseId = warehouseId;

            await _zoneRepository.CreateAsync(zone);

            return Created($"/api/topics/{warehouseId}/posts/{zone.Id}", _mapper.Map<ZoneDto>(zone));
        }
    }

    [HttpPut("{zoneId}")]
    [Authorize(Roles = WarehouseRoles.Admin + ", " + WarehouseRoles.Manager)]
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
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, oldZone, PolicyNames.ResourceOwner);
            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }
            oldZone.Name = zoneDto.Name is null ? oldZone.Name : zoneDto.Name;
            await _zoneRepository.UpdateAsync(oldZone);

            return Ok(_mapper.Map<ZoneDto>(oldZone));
        }
    }

    [HttpDelete("{zoneId}")]
    [Authorize(Roles = WarehouseRoles.Admin + ", " + WarehouseRoles.Manager)]
    public async Task<ActionResult> Remove(int warehouseId, int zoneId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);
        if (warehouse == null) return NotFound($"Couldn't find a warehouse with id of {warehouseId}");
        var zone = await _zoneRepository.GetAsync(warehouseId, zoneId);
        if (zone == null)
            return NotFound($"Zone {zoneId}id does not exist");
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, zone, PolicyNames.ResourceOwner);
        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }
        await _zoneRepository.DeleteAsync(zone);

        // 204
        return NoContent();
    }


}

