namespace MuslimSalat.DAL.Repositories.Interfaces;

public interface IRepository<Entity> : IRepositoryReader<Entity>, IRepositoryWriter<Entity>, IRepositoryRemover<Entity> where Entity : class
{
    
}
