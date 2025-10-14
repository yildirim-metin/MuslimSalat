namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IRepositoryReader<Entity> where Entity : class
{
    IEnumerable<Entity> GetAll();
    Entity GetOne(int id);
}
