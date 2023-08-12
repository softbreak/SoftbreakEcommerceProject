using System.Linq.Expressions;
using Project.ENTITIES.Interfaces;

namespace Project.DAL.Repositories.Interfaces;

public interface IGenericReadRepository<T> where T : class, IEntity, new()
{
    IQueryable<T> GetAll();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
    Task<bool>AnyAsync(Expression<Func<T, bool>> predicate);


}