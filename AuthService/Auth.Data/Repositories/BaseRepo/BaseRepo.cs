using Auth.Core.Interfaces.BaseRepo;
using Auth.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.Repositories.BaseRepo
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class
    {
        private readonly DeliveryAuthDb _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepo(DeliveryAuthDb context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
