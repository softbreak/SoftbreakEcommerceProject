using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class OrderDetailManager:BaseManager<OrderDetail>,IOrderDetailManager
    {
        IOrderDetailRepository _odRep;
        public OrderDetailManager(IOrderDetailRepository odRep):base(odRep)
        {
            _odRep = odRep;
        }
    }
}
