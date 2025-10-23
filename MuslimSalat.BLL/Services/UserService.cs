using Isopoh.Cryptography.Argon2;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Login(string emailOrUsermane, string password)
    {
        User user = _userRepository.GetOne(emailOrUsermane) ?? throw new Exception("User not found!");

        if (!Argon2.Verify(user.PasswordHash, password))
        {
            throw new Exception("Wrong Password");
        }

        return user;
    }

    public void Register(User user, string password)
    {
        user.PasswordHash = Argon2.Hash(password);
        _userRepository.Add(user);
    }
    
    public User GetUser(int id)
    {
        return _userRepository.GetOne(id) ?? throw new Exception("User not found!");
    }

    public void Update(User user)
    {
        if (!_userRepository.Any(u => u.Id == user.Id))
        {
            throw new Exception("User not found!");
        }
        _userRepository.Update(user);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }
}
