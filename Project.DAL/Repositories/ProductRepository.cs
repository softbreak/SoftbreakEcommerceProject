using Project.DAL.Context;
using Project.DAL.Repositories.Interfaces;
using Project.ENTITIES.Models;

namespace Project.DAL.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(MyContext context) : base(context)
    {
    }
}