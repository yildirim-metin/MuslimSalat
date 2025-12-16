using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IUserService
{
    public User Login(string emailOrUsername, string password);
    public void Register(User user, string password);
    public User GetUser(int id);
    public User Add(User user);
    public void Update(User user);
    public void Delete(int id);

    IEnumerable<User> GetAll();
}
