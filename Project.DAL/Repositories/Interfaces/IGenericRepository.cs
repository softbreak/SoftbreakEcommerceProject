using Project.ENTITIES.Interfaces;

namespace Project.DAL.Repositories.Interfaces;

public interface IGenericRepository<T> : IGenericReadRepository<T>, IGenericWriteRepository<T> where T:class,IEntity,new()
{
    
}