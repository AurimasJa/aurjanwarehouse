namespace APIWarehouse.Data.Dtos;

public record ZoneDto(int Id, string Name);
public record CreateZoneDto(string Name);
public record UpdateZoneDto(string? Name);