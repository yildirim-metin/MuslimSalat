using System.ComponentModel.DataAnnotations;

namespace MuslimSalat.API.Models.Users;

public class UserFormDto
{
    public int? Id { get; set; }
    public string? Username { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }
    
    public string? Role { get; set; }
}
