using Auth.Core.Entities;
using Auth.Core.Interfaces.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Repositories
{
    public interface IRoleRepo:IBaseRepo<Role>
    {
        IEnumerable<Role> GetRolesByUserId(int userId);
        Task<Role> GetRoleByName(string name);
    }
}
