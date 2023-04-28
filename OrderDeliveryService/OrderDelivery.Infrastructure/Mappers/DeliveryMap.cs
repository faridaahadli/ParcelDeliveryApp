using AutoMapper;
using OrderDelivery.Core.Entities;
using OrderDelivery.Infrastructure.Commands;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Mappers
{
    public class DeliveryMap:Profile
    {
        public DeliveryMap()
        {
            CreateMap<CreateDeliveryCommand, CreateDeliveryResponse>().ReverseMap();
            CreateMap<Delivery, CreateDeliveryResponse>().ReverseMap();
            CreateMap<Delivery, CreateDeliveryCommand>().ReverseMap();
            CreateMap<GetDeliveryResponse, Delivery>().ReverseMap();
            CreateMap<GetDeliveryTypeResponse, DeliveryType>().ReverseMap();
        }
    }
}
