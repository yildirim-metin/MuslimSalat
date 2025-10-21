using MuslimSalat.API.Models.Users;
using MuslimSalat.DL.Entities;
using MuslimSalat.DL.Enums;

namespace MuslimSalat.API.Mappers;

public static class UserMappers
{
    public static User ToUser(this RegisterFormDto userDto)
    {
        return new()
        {
            Username = userDto.Username,
            Email = userDto.Email,
            RoleValue = Enum.TryParse<UserRole>(userDto.Role, out var role) ? role : UserRole.User,
            IdAddressNavigation = userDto.Address?.ToAddress(),
        };
    }

    public static User CopyFromRegisterFormDto(this User user, RegisterFormDto registerFormDto)
    {
        user.Username = registerFormDto.Username;
        user.Email = registerFormDto.Email;
        user.RoleValue = Enum.TryParse<UserRole>(registerFormDto.Role, out var role) ? role : UserRole.User;
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
