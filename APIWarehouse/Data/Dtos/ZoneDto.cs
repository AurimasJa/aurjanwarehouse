using System.ComponentModel.DataAnnotations;

namespace APIWarehouse.Data.Dtos;

public record ZoneDto(int Id, string Name);
public record CreateZoneDto([Required] string Name);
public record UpdateZoneDto(string? Name);