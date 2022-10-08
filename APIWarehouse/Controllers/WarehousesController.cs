using APIWarehouse.Data.Dtos;
using APIWarehouse.Data.Models;
using APIWarehouse.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIWarehouse.Controllers;
[ApiController]
[Route("api/warehouses")]
public class WarehousesController : ControllerBase
{
    private readonly IWarehousesRepository _warehousesRepository;
    public WarehousesController(IWarehousesRepository warehousesRepository)
    {
        _warehousesRepository = warehousesRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<WarehouseDto>> GetMany()
    {
        var warehouses = await _warehousesRepository.GetManyAsync();
        return warehouses.Select(x => new WarehouseDto(x.Id, x.Name, x.Description));
    }
    [HttpGet("{warehouseId}", Name = "GetWarehouse")]
    public async Task<ActionResult<Warehouse>> Get(int warehouseId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);

        // 404
        if (warehouse == null)
            return NotFound();


        var warehouse1 = new Warehouse(warehouse.Id, warehouse.Name, warehouse.Description);
        return warehouse1;

    }
    [HttpPost]
    public async Task<ActionResult<WarehouseDto>> Create(CreateWarehouseDto createWarehouseDto)
    {
        var war = new Warehouse
        { Name = createWarehouseDto.Name, Description = createWarehouseDto.Description };

        await _warehousesRepository.CreateAsync(war);


        //return Created("", new { id = war.Id });
        // 201
        return Created("", new WarehouseDto(war.Id, war.Name, war.Description));
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
            return NotFound();

        warehouse.Description = updateWarehouseDto.Description;
        await _warehousesRepository.UpdateAsync(warehouse);

        return Ok(new Warehouse(warehouse.Id, warehouse.Name, warehouse.Description));
    }

    [HttpDelete("{warehouseId}", Name = "DeleteWarehouse")]
    public async Task<ActionResult> Remove(int warehouseId)
    {
        var warehouse = await _warehousesRepository.GetAsync(warehouseId);

        // 404
        if (warehouse == null)
            return NotFound();

        await _warehousesRepository.DeleteAsync(warehouse);


        // 204
        return NoContent();
    }
}