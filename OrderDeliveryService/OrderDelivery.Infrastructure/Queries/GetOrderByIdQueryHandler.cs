using AutoMapper;
using OrderDelivery.Core.Interfaces.Queries;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Data.Exceptions;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Queries
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, GetOrderResponse>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        public GetOrderByIdQueryHandler(IOrderRepo orderRepo,IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public async Task<GetOrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
           
            var order = await _orderRepo
                .GetById(request.Id);
            if (order == null)
                throw new CustomException("Order doesn't exist", HttpStatusCode.BadRequest);
            var result = _mapper.Map<GetOrderResponse>(order);
            return result;
        }
    }
}
