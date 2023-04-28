using Auth.Core.Interfaces.Queries;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{
    public class LoginQuery:IQuery<LoginResponse>
    {
        public string Email{ get; set; }
        public string Password { get; set; }
    }
}
