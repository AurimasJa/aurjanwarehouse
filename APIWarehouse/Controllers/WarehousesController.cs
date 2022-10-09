using APIWarehouse.Data.Dtos;
using APIWarehouse.Data.Models;
using APIWarehouse.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIWarehouse.Controllers;
[ApiController]
[Route("api/warehouses")]
public class WarehousesController : ControllerBase
{
    private readonly IWarehousesRepository _warehousesRepository;
    private readonly IMapper _mapper;
    public WarehousesController(IWarehousesRepository warehousesRepository, IMapper mapper)
    {
        _warehousesRepository = warehousesRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<WarehouseDto>> GetMany()
    {
        var warehouses = await _warehousesRepository.GetManyAsync();
        return warehouses.Select(x => new WarehouseDto(x.Id, x.Name, x.Description, x.Address, x.CreationDate));
    }
    [HttpGet("{warehouseId}", Name = "GetWarehouse")]
    public async Task<ActionResult<Warehouse>> Get(int warehouseId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);

        // 404
        if (warehouse == null)
            return NotFound($"Couldn't find a warehouse with id of {warehouseId}"); ;


        // var warehouse1 = new Warehouse(warehouse.Id, warehouse.Name, warehouse.Description, warehouse.Address, warehouse.CreationDate);
        return new Warehouse(warehouse.Id, warehouse.Name, warehouse.Description, warehouse.Address, warehouse.CreationDate);

    }
    
    [HttpGet]
    [Route("{warehouseId}/GetAllItems")]
    public async Task<IEnumerable<ItemDto>> GetAll(int warehouseId)
    {
        var items = await _warehousesRepository.GetManyAsyncItemsFromWarehouse(warehouseId);
        return items.Select(x => _mapper.Map<ItemDto>(x));
    }
    [HttpPost]
    public async Task<ActionResult<WarehouseDto>> Create(CreateWarehouseDto createWarehouseDto)
    {
        var war = new Warehouse
        { Name = createWarehouseDto.Name, Description = createWarehouseDto.Description, Address = createWarehouseDto.Address, CreationDate = DateTime.UtcNow };

        await _warehousesRepository.CreateAsync(war);


        //return Created("", new { id = war.Id });
        // 201
        return Created("", new WarehouseDto(war.Id, war.Name, war.Description, war.Address, DateTime.Now));
        //return CreatedAtAction("GetTopic", new { topicId = topic.Id }, new TopicDto(topic.Name, topic.Description, topic.CreationDate));
    }

    // api/topics
    [HttpPut]
    [Route("{warehouseId}")]
    public async Task<ActionResult<WarehouseDto>> Update(int warehouseId, UpdateWarehouseDto updateWarehouseDto)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);

        // 404
        if (warehouse == null)
            return NotFound($"Couldn't find a warehouse with id of {warehouseId}"); ;

        warehouse.Description = updateWarehouseDto.Description is null ? warehouse.Description : updateWarehouseDto.Description;
        warehouse.Address = updateWarehouseDto.Address is null ? warehouse.Address : updateWarehouseDto.Address;
        await _warehousesRepository.UpdateAsync(warehouse);

        return Ok(new Warehouse(warehouse.Id, warehouse.Name, warehouse.Description, warehouse.Address, warehouse.CreationDate));
    }

    [HttpDelete("{warehouseId}", Name = "DeleteWarehouse")]
    public async Task<ActionResult> Remove(int warehouseId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);

        // 404
        if (warehouse == null)
            return NotFound($"Couldn't find a warehouse with id of {warehouseId}"); ;

        await _warehousesRepository.DeleteAsync(warehouse);


        // 204
        return NoContent();
    }
}