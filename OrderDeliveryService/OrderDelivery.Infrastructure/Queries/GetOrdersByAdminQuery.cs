using OrderDelivery.Core.Interfaces.Queries;
using OrderDelivery.Core.Model;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Queries
{
    public class GetOrdersByAdminQuery: IQuery<IEnumerable<GetOrderResponse>>
    {
        public int Id { get; set; }
        public bool IsCourier { get; set; }
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
