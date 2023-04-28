using AutoMapper;
using OrderDelivery.Core.Entities;
using OrderDelivery.Core.Enums;
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
    public class UpdateOrderByUserCommandHandler : ICommandHandler<UpdateOrderByUserCommand, CreateOrderResponse>
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOrderByUserCommandHandler(IOrderRepo orderRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateOrderResponse> Handle(UpdateOrderByUserCommand request, CancellationToken cancellationToken)
        {

            Order order = await _orderRepo.GetByIdUser(request.Id,request.UserId,false);
            if (order == null)
                throw new CustomException("Order doesn't exist");
            if (request.IsCanceled && order.Status == (int)DeliveryStatus.Pending)
            {
                order.Status = (int)DeliveryStatus.Canceled;
            }
            else
            {
                if (order.Status == (int)DeliveryStatus.Going ||
                order.Status == (int)DeliveryStatus.Arrived || order.Status == (int)DeliveryStatus.Canceled)
                    throw new CustomException("Order cant update");

                order.Address = request.Address;

            }            
            _orderRepo.Update(order);
            await _unitOfWork.SaveChangesAsync();
            CreateOrderResponse result = _mapper.Map<CreateOrderResponse>(order);
            return result;
        }


    }
}
