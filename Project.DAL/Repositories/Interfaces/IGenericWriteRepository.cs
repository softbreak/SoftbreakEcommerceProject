using Project.ENTITIES.Interfaces;

namespace Project.DAL.Repositories.Interfaces;

public interface IGenericWriteRepository<T> where T : class,IEntity,new()
{
    T Insert(T entity);
    void InsertRange (IEnumerable<T> entities);

    T Edit(T entity);
    
    void Delete(T entity);
    void DeleteById (int id);
    void DeleteRange(IEnumerable<T> entities);

}