using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected IRepository<T> _irp;

        public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }

        public string Add(T item)
        {

            if (item.CreatedDate != null)
            {
                _irp.Add(item);
                return "Ekleme basarılıdır";
            }
            return "Ekleme basarısız";
        }

        public async Task AddAsync(T item)
        {
            //Todo : BL buraya yazılacak
            await _irp.AddAsync(item);
        }

        public void AddRange(List<T> list)
        {
            _irp.AddRange(list);
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _irp.AddRangeAsync(list);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _irp.AnyAsync(exp);
        }

        public void Delete(T item)
        {
            _irp.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            _irp.DeleteRange(list);
        }

        public void Destroy(T item)
        {
            _irp.Destroy(item);
        }

        public void DestroyRange(List<T> list)
        {
            _irp.DestroyRange(list);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _irp.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _irp.FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
           return _irp.GetActives();
        }

        public IQueryable<T> GetAll()
        {
            return _irp.GetAll();
        }

        public IQueryable<T> GetModifieds()
        {
            return _irp.GetModifieds();
        }

        public IQueryable<T> GetPassives()
        {
            return _irp.GetPassives();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _irp.Select(exp);
        }

        public async Task Update(T item)
        {
            await _irp.Update(item);
        }

        public async Task UpdateRange(List<T> list)
        {
            await _irp.UpdateRange(list);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _irp.Where(exp);
        }
    }
}
