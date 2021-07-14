using MediatR;
using System;
using System.Collections.Generic;

namespace Ordering.Application.CQRS.Orders.Queries.GetOrdersList
{
    public class GetOrdersByUsernameQuery : IRequest<List<OrdersByUsernameQueryResult>>
    {
        public string UserName { get; set; }

        public GetOrdersByUsernameQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
    }
}
