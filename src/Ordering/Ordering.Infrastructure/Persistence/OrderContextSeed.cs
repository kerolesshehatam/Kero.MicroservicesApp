using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext)
        {
            orderContext.Database.Migrate();
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "Keroles",
                            FirstName = "Keroles",
                            LastName = "Shehata",
                    EmailAddress = "keroles@gmail.com", AddressLine = "Cairo", Country = "Egypt", TotalPrice = 350 }
            };
        }
    }

}
