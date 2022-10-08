namespace APIWarehouse.Data.Dtos;

public record WarehouseDto(int Id, string Name, string Description);
public record CreateWarehouseDto(string Name, string Description);
public record UpdateWarehouseDto(string Description);