using System.ComponentModel.DataAnnotations;

namespace APIWarehouse.Data.Dtos;

public record ItemDto(int Id, string Name, string Description);
public record CreateItemDto([Required] string Name, [Required] string Description);
public record UpdateItemDto(string? Name, string? Description);

