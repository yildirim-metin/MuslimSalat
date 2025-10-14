namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IRepositoryRemover<Entity> where Entity : class
{
    bool Delete(Entity entity);
    bool Delete(int id);
    bool DeleteRange(IEnumerable<Entity> entities);
}
