using AutoMapper;
using Ordering.Application.CQRS.Orders.Commands.CheckoutOrder;
using Ordering.Application.CQRS.Orders.Commands.UpdateOrder;
using Ordering.Application.CQRS.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersByUsernameQueryResult>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
