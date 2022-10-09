namespace APIWarehouse.Data.Dtos;

public record ItemDto(int Id, string Name, string Description);
public record CreateItemDto(string Name, string Description);
public record UpdateItemDto(string? Name, string? Description);

