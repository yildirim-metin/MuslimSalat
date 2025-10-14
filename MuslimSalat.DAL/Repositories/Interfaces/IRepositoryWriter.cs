namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IRepositoryWriter<Entity> where Entity : class
{
    bool Add(Entity entity);
    bool Update(Entity entity);
}
