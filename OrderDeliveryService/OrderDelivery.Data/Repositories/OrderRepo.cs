using Microsoft.EntityFrameworkCore;
using OrderDelivery.Core.Entities;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Data.AppDbContext;
using OrderDelivery.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Data.Repositories
{
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private readonly ParcelDeliveryDb _context;
        public OrderRepo(ParcelDeliveryDb context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetById(int orderId)
        {
            return await _context.Orders.Include(p=>p.Deliveries).FirstOrDefaultAsync(x => x.Id == orderId);
        }
        public async Task<Order> GetByIdUser(int orderId, int userId, bool isCourier)
        {

            if (!isCourier)
                return await _context.Orders
                             .Include(
                               p => p.Deliveries.Where(p => p.CourierId == userId)
                               )
                             .FirstOrDefaultAsync(p => p.Id == orderId);
            else
                return await _context.Orders
                          .Include(
                            p => p.Deliveries.Where(p => p.CourierId == userId)
                            )
                          .FirstOrDefaultAsync(p => p.Id == orderId);

        }

        public async Task<IEnumerable<Order>> GetAll(int countPerPage, int currentPage)
        {
            int skipCount = (currentPage - 1) * countPerPage;
            return await _context.Orders
                .Include(p=>p.DeliveryType)
                .Include(p => p.Deliveries)
                .OrderByDescending(p => p.CreateDate)
                .Skip(skipCount)
                .Take(countPerPage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId, bool isCourier, int countPerPage, int currentPage)
        {
            int skipCount = (currentPage - 1) * countPerPage;

            if (isCourier)
                return await _context.Orders
                .Include(p=>p.DeliveryType)
                .Include(p =>
                       p.Deliveries.Where(x => x.CourierId == userId)
                       )
                .OrderByDescending(p => p.CreateDate)
                .Skip(skipCount)
                .Take(countPerPage)
                .ToListAsync();
            else
                return await _context.Orders.Where(o => o.AuthorId == userId)
                .Include(p => p.DeliveryType)
                .Include(p => p.Deliveries)
                .OrderByDescending(p => p.CreateDate)
                .Skip(skipCount)
                .Take(countPerPage)
                .ToListAsync();

        }


    }
}
