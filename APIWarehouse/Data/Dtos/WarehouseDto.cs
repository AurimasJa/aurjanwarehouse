﻿using System.ComponentModel.DataAnnotations;

namespace APIWarehouse.Data.Dtos;

public record WarehouseDto(int Id, string Name, string Description, string Address, DateTime CreationDate);
public record CreateWarehouseDto([Required] string Name, [Required] string Description, [Required] string Address, DateTime CreationDate);
public record UpdateWarehouseDto(string? Description, string? Address);