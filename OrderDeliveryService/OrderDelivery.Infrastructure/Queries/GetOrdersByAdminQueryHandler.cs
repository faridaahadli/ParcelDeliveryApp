using AutoMapper;
using OrderDelivery.Core.Interfaces.Queries;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Queries
{
    public class GetOrdersByAdminQueryHandler : IQueryHandler<GetOrdersByAdminQuery, IEnumerable<GetOrderResponse>>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        public GetOrdersByAdminQueryHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetOrderResponse>> Handle(GetOrdersByAdminQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<GetOrderResponse> result = new List<GetOrderResponse>();
            var orders = await _orderRepo
                .GetAll(request.Pagination.CountPerPage, request.Pagination.CurrentPage);
            if (orders == null)
                return result;
            result = _mapper.Map<IEnumerable<GetOrderResponse>>(orders);
            return result;
        }
    }
}
