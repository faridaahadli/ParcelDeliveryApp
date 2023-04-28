using OrderDelivery.Core.Interfaces.Queries;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Queries
{
    public class GetOrderByIdQuery:IQuery<GetOrderResponse>
    {
        public int Id { get; set; }
        public bool IsCourier { get; set; }
    }
}
