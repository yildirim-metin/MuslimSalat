namespace MuslimSalat.API.Models.Users;

public record class UserDto
{
    public int Id { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public int? IdAddress { get; set; }

    public AddressDto? Address { get; set; }
}
