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
    public async Task<IReadOnlyList<Warehouse>> GetMany()
    {
        var warehouses = await _warehousesRepository.GetManyAsync();
        return (IReadOnlyList<Warehouse>)warehouses.Select(x => new Warehouse(x.Id, x.Name, x.Description));
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
    public async Task<ActionResult<Warehouse>> Create(CreateWarehouseDto createWarehouseDto)
    {
        var war = new Warehouse
        { Name = createWarehouseDto.Name, Description = createWarehouseDto.Description };

        await _warehousesRepository.CreateAsync(war);


        return Created("", new { id = war.Id });
        // 201
     //   return Created("", new TopicDto(topic.Id, topic.Name, topic.Description, topic.CreationDate));
        //return CreatedAtAction("GetTopic", new { topicId = topic.Id }, new TopicDto(topic.Name, topic.Description, topic.CreationDate));
    }
}