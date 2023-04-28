using Auth.Core.Entities;
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
    public class UserRepo :BaseRepo<User>, IUserRepo
    {
        private readonly DeliveryAuthDb _context;
        public UserRepo(DeliveryAuthDb context):base(context)
        { 
            _context = context;
        }

        public async Task<bool> CheckUniqueEmail(string email)
        {
           return await _context.Users.AnyAsync(p=>p.Email == email);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees
                .Include(p=>p.User)  
               .FirstOrDefaultAsync(p => p.UserId == id);
        }
        public async Task<IEnumerable<Employee>> GetEmployees(int currentPage,int countPerPage)
        {
            int skipCount = (currentPage - 1) * countPerPage;
            return await _context.Employees                              
                .Include(p => p.User)
                .Skip(skipCount)   
                .Take(countPerPage)
                .ToListAsync();
        }
        public async Task<User> GetUser(User user)
        {
           return await _context.Users
                .FirstOrDefaultAsync(p => p.Email == user.Email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users
               .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
               .FirstOrDefaultAsync(p => p.Id==id);
        }
    }
}
