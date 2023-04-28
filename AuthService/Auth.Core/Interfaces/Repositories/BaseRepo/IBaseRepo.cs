using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.BaseRepo
{
    public interface IBaseRepo<TEntity> where TEntity : class  
    {       
            Task AddAsync(TEntity entity);
            Task<int> Update(TEntity entity);
            Task<bool> Delete(int Id);
    }
}
