using System;
using Orders.Domain.SeedWork;

namespace Orders.Domain.Model
{
    public class OrderEvent : Entity
    {
        private OrderEvent()
        {

        }

        public static OrderEvent Raise(OrderStatus status, string reason = null, DateTime? eventDate = null)
        {
            if (status == null) throw new ArgumentNullException(nameof(status));

            return new OrderEvent
            {
                EventDate = eventDate ?? DateTime.UtcNow,
                OrderStatus = status,
                Reason = reason
            };
        }

        public OrderStatus OrderStatus { get; private set; }
        public DateTime EventDate { get; private set; }
        public string Reason { get; private set; }
    }
}