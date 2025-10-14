namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IRepositoryReader<Entity> where Entity : class
{
    IEnumerable<Entity> GetAll(Func<Entity, bool>? predicate = null);
    Entity? GetOne(int id);
}
