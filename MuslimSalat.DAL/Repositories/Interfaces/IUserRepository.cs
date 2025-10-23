using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    public User? GetOne(string emailOrUsername);
}
