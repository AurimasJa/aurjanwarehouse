using System.ComponentModel.DataAnnotations;

namespace APIWarehouse.Auth.Model;

public record RegisterUserDto([Required] string UserName, [EmailAddress][Required] string Email, [Required] string Password);
public record LoginDto(string UserName, string Password);
public record UserDto(string id, string UserName, string Password);
public record SuccessfulLoginDto(string AccessToken);