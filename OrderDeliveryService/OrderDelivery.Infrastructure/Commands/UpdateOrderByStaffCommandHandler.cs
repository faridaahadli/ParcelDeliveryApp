using AutoMapper;
using OrderDelivery.Core.Entities;
using OrderDelivery.Core.Interfaces.Commands;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Core.Interfaces.UnitOfWork;
using OrderDelivery.Data.Exceptions;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Commands
{
    public class UpdateOrderByStaffCommandHandler : ICommandHandler<UpdateOrderByStaffCommand, CreateOrderResponse>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOrderByStaffCommandHandler(IOrderRepo orderRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateOrderResponse> Handle(UpdateOrderByStaffCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepo.GetByIdUser(request.Id,request.UserId,true);
            if (order == null)
                throw new CustomException("Order doesn't exist");
            order.Status = request.Status;
            _orderRepo.Update(order);
            await _unitOfWork.SaveChangesAsync();
            CreateOrderResponse result = _mapper.Map<CreateOrderResponse>(order);
            return result;
        }
    }
}
