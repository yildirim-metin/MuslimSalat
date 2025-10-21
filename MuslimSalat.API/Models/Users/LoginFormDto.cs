namespace MuslimSalat.API.Models.Users;

public record LoginFormDto
{
    public required string EmailOrUsername { get; set; }
    public required string Password { get; set; }
}
