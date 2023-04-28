using Auth.Core.Entities;
using Auth.Core.Interfaces.BaseRepo;
using Auth.Core.Interfaces.Repositories;
using Auth.Data.AppDbContext;
using Auth.Data.Repositories.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.Repositories
{
    public class RoleRepo :BaseRepo<Role>,IRoleRepo
    {
        private readonly DeliveryAuthDb _context;
        public RoleRepo(DeliveryAuthDb context ):base(context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetRolesByUserId(int userId)
        {
            return _context.UserToRoles.Include(p=>p.Role)
                   .Where(p=>p.UserId==userId).Select(p=>p.Role);
        }
        public async Task<Role> GetRoleByName(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(p=>p.Name==name);
        }
    }
}
