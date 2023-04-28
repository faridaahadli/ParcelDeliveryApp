using Auth.Core.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{
    public class CheckEmployeeStatusQuery:IQuery<bool>
    {
        public int Id { get; set; }
    }
}
