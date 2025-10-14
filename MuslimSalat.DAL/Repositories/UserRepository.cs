using Microsoft.EntityFrameworkCore;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories.Interfaces;
using MuslimSalat.DL.Entities;

namespace MuslimSalat.DAL.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly MuslimSalatContext _context;
    private readonly DbSet<User> _users;

    public UserRepository(MuslimSalatContext context)
    {
        _context = context;
        _users = context.Set<User>();
    }
    
    public bool Add(User entity)
    {
        _users.Add(entity);
        return _context.SaveChanges() == 1;
    }

    public bool Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRange(IEnumerable<User> entities)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(User entity)
    {
        throw new NotImplementedException();
    }
}
