using Auth.Core.Interfaces.Queries;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{

    public class GetEmployeeQuery:IQuery<GetEmployeeResponse>
    {
        public int UserId { get; set; }
    }
}
