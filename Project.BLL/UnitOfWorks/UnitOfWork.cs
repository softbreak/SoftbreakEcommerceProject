using AutoMapper;
using Project.DAL.Context;
using Project.DAL.Repositories;
using Project.DAL.Repositories.Interfaces;

namespace Project.BLL.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{

    private readonly MyContext _context;
    private readonly IMapper _mapper;
    public UnitOfWork(MyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IMapper Mapper => _mapper;
    public ICategoryRepository GetCategoryRepository() => new CategoryRepository(_context);
    public IOrderRepository GetOrderRepository() => new OrderRepository(_context);
    public IProductRepository GetProductRepository() => new ProductRepository(_context);


    public int Save() => _context.SaveChanges();

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public async ValueTask DisposeAsync() =>await _context.DisposeAsync();

}