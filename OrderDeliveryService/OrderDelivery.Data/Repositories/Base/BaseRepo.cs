using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrderDelivery.Core.Interfaces.Repositories.BaseRepo;
using OrderDelivery.Data.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Data.Repositories.Base
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class
    {
        private readonly ParcelDeliveryDb _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepo(ParcelDeliveryDb context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async  Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void  Update(TEntity entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<TEntity>(entity);
            dbEntityEntry.State = EntityState.Modified;
           
        }
    }
}
