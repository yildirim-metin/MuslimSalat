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

    public static UserFormDto ToUserFormDto(this User user)
    {
        return new()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.RoleValue.ToString(),
        };
    }

    public static User ToUser(this UserFormDto userDto)
    {
        return new()
        {
            Id = userDto.Id ?? 0,
            Username = userDto.Username,
            Email = userDto.Email,
            RoleValue = Enum.TryParse<UserRole>(userDto.Role, out var role) ? role : UserRole.User,
        };
    }

    public static User CopyFromUserFormDto(this User user, UserFormDto userFormDto)
    {
        user.Id = userFormDto.Id ?? throw new ArgumentException("User ID is required.");
        user.Username = userFormDto.Username;
        user.Email = userFormDto.Email;
        user.RoleValue = Enum.TryParse<UserRole>(userFormDto.Role, out var role) ? role : UserRole.User;
        return user;
    }

    public static IEnumerable<UserFormDto> ToUserFormDto(this IEnumerable<User> users)
    {
        return users.Select(user => user.ToUserFormDto());
    }
}