using Auth.Core.Interfaces.UnitOfWork;
using Auth.Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryAuthDb _context;
        public UnitOfWork(DeliveryAuthDb context)
         =>_context = context;

        public Task SaveChangesAsync()
        =>_context.SaveChangesAsync();
    }
}
