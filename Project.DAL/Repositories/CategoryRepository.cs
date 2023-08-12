using Project.DAL.Context;
using Project.DAL.Repositories.Interfaces;
using Project.ENTITIES.Models;

namespace Project.DAL.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(MyContext context) : base(context)
    {
    }
}