using MuslimSalat.DL.Entities;

namespace MuslimSalat.BLL.Services.Interfaces;

public interface IUserService
{
    public User Login(string username, string password);
    public void Register(User user, string password);
    public User GetUser(int id);
    public void Update(User user);
    public void Delete(int id);
}
