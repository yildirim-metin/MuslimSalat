using MuslimSalat.DAL.Configs;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(MuslimSalatContext context) : base(context)
    {
    }

    public User? GetOne(string username)
    {
        return _data.Where(u => u.Username == username).SingleOrDefault();
    }
}
