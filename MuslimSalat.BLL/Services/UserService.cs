using Isopoh.Cryptography.Argon2;
using MuslimSalat.DAL.Repositories;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Add(User user, string password)
    {
        user.PasswordHash = Argon2.Hash(password);
        _userRepository.Add(user);
    }
}
