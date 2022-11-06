using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace APIWarehouse.Data.Dtos;

public record ItemDto(int Id, string Name, string Description);
public record CreateItemDto([Required] string Name, [Required] string Description);
public record UpdateItemDto(string? Name, string? Description, int ZoneIdAsked);

