using Auth.Core.Interfaces.Queries;
using Auth.Core.Model;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{
    public class GetEmployeesQuery:IQuery<IEnumerable<GetEmployeeResponse>>
    {
        public Pagination Pagination { get; set; }=new Pagination();
    }
}
