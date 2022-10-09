namespace APIWarehouse.Data.Dtos;

public record WarehouseDto(int Id, string Name, string Description, string Address, DateTime CreationDate);
public record CreateWarehouseDto(string Name, string Description, string Address, DateTime CreationDate);
public record UpdateWarehouseDto(string? Description, string? Address);