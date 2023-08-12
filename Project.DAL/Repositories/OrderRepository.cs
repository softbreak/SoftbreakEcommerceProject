using Project.DAL.Context;
using Project.DAL.Repositories.Interfaces;
using Project.ENTITIES.Models;

namespace Project.DAL.Repositories;

public class OrderRepository : GenericRepository<Order>,IOrderRepository
{
    public OrderRepository(MyContext context) : base(context)
    {
    }
}