using MuslimSalat.API.Models.Users;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.API.Mappers;

public static class UserMappers
{
    public static User ToUser(this RegisterFormDto userDto)
    {
        return new()
        {
            Username = userDto.Username,
            IdAddressNavigation = userDto.Address?.ToAddress(),
        };
    }

    public static User CopyFromRegisterFormDto(this User user, RegisterFormDto registerFormDto)
    {
        user.Username = registerFormDto.Username;
        user.IdAddressNavigation = registerFormDto.Address?.ToAddress();
        return user;
    }

    public static Address ToAddress(this AddressDto addressDto)
    {
        return new()
        {
            Id = addressDto.Id,
            PostCode = addressDto.PostCode,
            Locality = addressDto.Locality,
            Longitude = addressDto.Longitude,
            Latitude = addressDto.Latitude,
        }; 
    }
}
