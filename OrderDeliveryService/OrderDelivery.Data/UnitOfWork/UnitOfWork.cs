using OrderDelivery.Core.Interfaces.UnitOfWork;
using OrderDelivery.Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParcelDeliveryDb _context;
        public UnitOfWork(ParcelDeliveryDb context)
         => _context = context;

        public Task SaveChangesAsync()
        => _context.SaveChangesAsync();
    }
}
