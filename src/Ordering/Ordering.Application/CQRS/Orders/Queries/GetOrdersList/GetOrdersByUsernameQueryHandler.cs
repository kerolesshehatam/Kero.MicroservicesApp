using AutoMapper;
using MediatR;
using Ordering.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.CQRS.Orders.Queries.GetOrdersList
{
    public class GetOrdersByUsernameQueryHandler : IRequestHandler<GetOrdersByUsernameQuery, List<OrdersByUsernameQueryResult>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersByUsernameQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersByUsernameQueryResult>> Handle(GetOrdersByUsernameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetOrdersByUserNameAsync(request.UserName);
            return _mapper.Map<List<OrdersByUsernameQueryResult>>(orderList);
        }
    }
}
