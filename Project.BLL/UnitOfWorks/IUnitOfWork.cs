using AutoMapper;
using Project.DAL.Repositories.Interfaces;

namespace Project.BLL.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IMapper Mapper{ get; }
    IProductRepository GetProductRepository();
    ICategoryRepository GetCategoryRepository();
    IOrderRepository GetOrderRepository();

    int Save();
    Task<int>SaveAsync();
}