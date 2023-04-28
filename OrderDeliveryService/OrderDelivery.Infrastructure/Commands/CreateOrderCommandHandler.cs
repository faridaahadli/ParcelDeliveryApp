using AutoMapper;
using OrderDelivery.Core.Entities;
using OrderDelivery.Core.Interfaces.Commands;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Core.Interfaces.UnitOfWork;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Commands
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CreateOrderResponse>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepo orderRepo,IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            
            Order order = _mapper.Map<Order>(request);
            await _orderRepo.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            CreateOrderResponse response = _mapper.Map<CreateOrderResponse>(order);
            return response; 
        }
    }
}
