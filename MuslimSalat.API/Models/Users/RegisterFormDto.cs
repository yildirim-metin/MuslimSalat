using System.ComponentModel.DataAnnotations;

namespace MuslimSalat.API.Models.Users;

public record class RegisterFormDto
{
    public required string Username { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }
    
    [Length(8, 100, ErrorMessage = "Password must be between 8 to 100 character")]
    public required string Password { get; set; }
    
    public string? Role { get; set; }
    public AddressDto? Address { get; set; }
}
