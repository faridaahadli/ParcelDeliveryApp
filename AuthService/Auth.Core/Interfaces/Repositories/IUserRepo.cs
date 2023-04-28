using Auth.Core.Entities;
using Auth.Core.Interfaces.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Repositories
{
    public interface IUserRepo:IBaseRepo<User>
    {
        Task<User> GetUserById(int id);
        Task<User> GetUser(User user);
        Task<User> GetUserByEmail(string email);
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetEmployees(int currentPage, int countPerPage);
        Task<bool> CheckUniqueEmail(string email);
    }
}
