using System.Data;
using Nevermore.Mapping;
using Orders.Domain.Model;

namespace Orders.Infrastructure.Storage
{
    public class OrderMap : DocumentMap<Order>
    {
        public OrderMap()
        {
            Column(o => o.OrderDate);
            VirtualColumn("OrderTotal", DbType.Decimal, document => document.OrderTotal);
            VirtualColumn("Canceled", DbType.Boolean, document => document.Canceled);
            VirtualColumn("CustomerName", DbType.String, document => document.Customer.Name);
        }
    }
}