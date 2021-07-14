using AutoMapper;
using EventBusRabbitMQ.Events;
using Ordering.Application.CQRS.Orders.Commands.CheckoutOrder;

namespace Ordering.API.Mapper
{
    public class OrderingProfile : Profile
	{
		public OrderingProfile()
		{
			CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
		}
	}
}
