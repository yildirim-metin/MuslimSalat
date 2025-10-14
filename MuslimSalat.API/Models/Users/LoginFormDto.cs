namespace MuslimSalat.API.Models.Users;

public record LoginFormDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
