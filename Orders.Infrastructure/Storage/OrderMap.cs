using Nevermore.Mapping;
using Orders.Domain.Model;

namespace Orders.Infrastructure.Storage
{
    public class OrderMap : DocumentMap<Order>
    {
        public OrderMap()
        {
            Column(o => o.Canceled);
            Column(o => o.OrderDate);
            Column(o => o.OrderTotal);
        }
    }
}