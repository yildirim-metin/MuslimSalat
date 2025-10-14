namespace MuslimSalat.API.Models.Users;

public class AddressDto
{
    public int Id { get; set; }

    public int PostCode { get; set; }

    public string? Locality { get; set; }

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }
}
