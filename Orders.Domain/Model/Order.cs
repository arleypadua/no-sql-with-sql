using System;
using System.Collections.Generic;
using System.Linq;
using Orders.Domain.SeedWork;

namespace Orders.Domain.Model
{
    public class Order : Entity, IAggregateRoot
    {
        private Order()
        {

        }

        public static Order NewOrder(Customer customer, List<OrderLine> products, DateTime? orderDate = null)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (products == null) throw new ArgumentNullException(nameof(products));
            if (products.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(products));

            var newOrderEvent = OrderEvent.Raise(OrderStatus.Created);

            return new Order
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                OrderDate = orderDate ?? DateTime.UtcNow,
                Products = products,
                Events = new [] { newOrderEvent }
            };
        }
        
        public Customer Customer { get; private set; }
        public DateTime OrderDate { get; private set; }

        private List<OrderLine> _products;
        private List<OrderEvent> _events;

        public IEnumerable<OrderLine> Products
        {
            get => _products;
            private set => _products = value.ToList();
        }

        public IEnumerable<OrderEvent> Events
        {
            get => _events;
            private set => _events = value.ToList();
        }

        public decimal OrderTotal => Products.Sum(p => p.Total);
        public bool Canceled => _events.Any(e => e.OrderStatus.Name == OrderStatus.Canceled.Name);

        public void SetPayed()
        {
            if(Canceled) return;
            
            _events.Add(OrderEvent.Raise(OrderStatus.Payed));
        }

        public void SetApproved(string reason)
        {
            if (Canceled) return;

            _events.Add(OrderEvent.Raise(OrderStatus.Approved, reason));
        }

        public void SetCanceled(string reason)
        {
            if (Canceled) return;

            _events.Add(OrderEvent.Raise(OrderStatus.Canceled, reason));
        }
    }
}