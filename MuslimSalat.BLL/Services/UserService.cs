using Isopoh.Cryptography.Argon2;
using MuslimSalat.BLL.Services.Interfaces;
using MuslimSalat.DAL.Repositories;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Login(string username, string password)
    {
        User user = _userRepository.GetOne(username) ?? throw new Exception("User not found!");

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
        _userRepository.Update(user);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }
}
