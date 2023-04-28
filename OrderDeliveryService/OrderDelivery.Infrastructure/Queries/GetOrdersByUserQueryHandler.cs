using AutoMapper;
using OrderDelivery.Core.Entities;
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
    public class GetOrdersByUserQueryHandler : IQueryHandler<GetOrdersByUserQuery, IEnumerable<GetOrderResponse>>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        public GetOrdersByUserQueryHandler(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetOrderResponse>> Handle(GetOrdersByUserQuery request, CancellationToken cancellationToken)
        {

            IEnumerable<GetOrderResponse> result = new List<GetOrderResponse>();
            IEnumerable<Order> orders = await _orderRepo
                .GetOrdersByUserId(request.Id,request.IsCourier,request.Pagination.CountPerPage, request.Pagination.CurrentPage);
            if (orders == null)
               return result;
            result = _mapper.Map<IEnumerable<GetOrderResponse>>(orders);
            return result;
        }
      
    }
}
