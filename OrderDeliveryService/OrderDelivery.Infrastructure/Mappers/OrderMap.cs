using AutoMapper;
using OrderDelivery.Core.Entities;
using OrderDelivery.Infrastructure.Commands;
using OrderDelivery.Infrastructure.Queries;
using OrderDelivery.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDelivery.Infrastructure.Mappers
{
    public class OrderMap:Profile
    {
        public OrderMap()
        {
            CreateMap<GetOrdersByUserQuery, GetOrderResponse>().ReverseMap();
            CreateMap<GetOrdersByAdminQuery, GetOrderResponse>().ReverseMap();
            CreateMap<GetOrdersByAdminQuery, Order>().ReverseMap();            
            CreateMap<Order, GetOrderResponse>().ReverseMap();
            CreateMap<Order, GetOrdersByUserQuery>().ReverseMap();
            CreateMap<GetOrderByIdQuery, GetOrderResponse>().ReverseMap();
            CreateMap<CreateOrderCommand, CreateOrderResponse>().ReverseMap();          
            CreateMap<Order, CreateOrderResponse>().ReverseMap();          
            CreateMap<CreateOrderCommand, Order>().ReverseMap();          
            CreateMap<UpdateOrderByUserCommand, CreateOrderResponse>().ReverseMap();
            CreateMap<UpdateOrderByUserCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderByStaffCommand, CreateOrderResponse>().ReverseMap();
            CreateMap<UpdateOrderByStaffCommand, Order>().ReverseMap();
            
        }
    }
}
