using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;
using Project.DAL.Repositories.Interfaces;
using Project.ENTITIES.Interfaces;

namespace Project.DAL.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T>
where T : class, IEntity, new()
{

    protected readonly MyContext _context;
    private DbSet<T> _table;
    private IQueryable<T> _query;

    public GenericRepository(MyContext context)
    {
        _context = context;
        _table = _context.Set<T>();
        _query = _table;
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _query.AnyAsync(predicate);

    public virtual void Delete(T entity) => _table.Remove(entity);

    public virtual void DeleteById(int id) => _table.Where(entity=> entity.ID == id).ExecuteDelete();

    public virtual void DeleteRange(IEnumerable<T> entities) => _table.RemoveRange(entities);

    public virtual T Edit(T entity)
    {
        _table.Update(entity);
        return entity;
    }

    public virtual T Insert(T entity)
    {
        _table.Add(entity);
        return entity;
    }

    public virtual void InsertRange(IEnumerable<T> entities)
    {
        _table.AddRange(entities);
    }

    public virtual IQueryable<T> GetAll() => _query.AsNoTracking().AsQueryable();

    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        _query = predicate != null ? _query.Where(predicate) : _query;
        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }

        return await _query.ToListAsync();
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        _query = _query.Where(predicate);

        if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }

        return await _query.SingleOrDefaultAsync();

    }

    public virtual async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        _query = _query.Where(entity => entity.ID == id);
         if (includeProperties.Length > 0)
        {
            foreach (var property in includeProperties)
            {
                _query = _query.Include(property);
            }
        }

        return await _query.SingleOrDefaultAsync();
    }

}
