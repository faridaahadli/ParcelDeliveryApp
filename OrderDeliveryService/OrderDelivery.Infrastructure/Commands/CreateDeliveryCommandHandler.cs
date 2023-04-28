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
    public class CreateDeliveryCommandHandler : ICommandHandler<CreateDeliveryCommand, CreateDeliveryResponse>
    {
        private readonly IDeliveryRepo _deliveryRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateDeliveryCommandHandler(IDeliveryRepo deliveryRepo, IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _deliveryRepo = deliveryRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateDeliveryResponse> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            Delivery delivery = _mapper.Map<Delivery>(request);
            await _deliveryRepo.AddAsync(delivery);
            await _unitOfWork.SaveChangesAsync();
            CreateDeliveryResponse response = _mapper.Map<CreateDeliveryResponse>(delivery);
            return response;
        }
    }
}
