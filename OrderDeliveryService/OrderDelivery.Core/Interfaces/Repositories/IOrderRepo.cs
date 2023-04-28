using OrderDelivery.Core.Entities;
using OrderDelivery.Core.Interfaces.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Core.Interfaces.Repositories
{
    public interface IOrderRepo:IBaseRepo<Order>
    {
        Task<Order> GetById(int orderId);
        Task<IEnumerable<Order>> GetAll(int countPerPage, int currentpage);
        Task<Order> GetByIdUser(int orderId, int userId, bool isCourier);
        Task<IEnumerable<Order>> GetOrdersByUserId(int userId, bool isCourier, int countPerPage, int currentpage);
    }
}
