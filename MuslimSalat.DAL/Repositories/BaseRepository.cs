using Microsoft.EntityFrameworkCore;
using MuslimSalat.DAL.Configs;
using MuslimSalat.DAL.Repositories.Interfaces;

namespace MuslimSalat.DAL.Repositories;

public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : class
{
    protected readonly MuslimSalatContext _context;
    protected readonly DbSet<Entity> _data;
    
    protected BaseRepository(MuslimSalatContext context)
    {
        _context = context;
        _data = context.Set<Entity>();
    }

    public bool Add(Entity entity)
    {
        _data.Add(entity);
        return _context.SaveChanges() == 1;
    }

    public bool Delete(Entity entity)
    {
        _data.Remove(entity);
        return _context.SaveChanges() == 1;
    }

    public bool Delete(int id)
    {
        Entity? entity = GetOne(id);
        return entity is not null && Delete(entity);
    }

    public bool DeleteRange(IEnumerable<Entity> entities)
    {
        _data.RemoveRange(entities);
        return _context.SaveChanges() == entities.Count();
    }

    public IEnumerable<Entity> GetAll(Func<Entity, bool>? predicate = null)
    {
        return predicate is not null ? _data.Where(predicate) : _data;
    }

    public Entity? GetOne(int id)
    {
        return _data.Find(id);
    }

    public bool Update(Entity entity)
    {
        _data.Update(entity);
        return _context.SaveChanges() == 1;
    }

    public bool Any(Func<Entity, bool>? predicate = null)
    {
        return predicate is not null ? _data.Any(predicate) : _data.Any();
    }
}
