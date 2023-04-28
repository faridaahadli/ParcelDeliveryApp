using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces.Jwt
{
    public interface IJwtManager
    {
        public Task<string> CreateToken(int userId);
    }
}

