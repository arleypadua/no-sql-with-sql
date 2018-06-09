using Orders.Domain.SeedWork;

namespace Orders.Domain.Model
{
    public class OrderStatus : Enumeration
    {
        public static readonly OrderStatus Created = new OrderStatus(1, nameof(Created).ToLowerInvariant());
        public static readonly OrderStatus Approved = new OrderStatus(2, nameof(Approved).ToLowerInvariant());
        public static readonly OrderStatus Canceled = new OrderStatus(3, nameof(Canceled).ToLowerInvariant());
        public static readonly OrderStatus Payed = new OrderStatus(4, nameof(Payed).ToLowerInvariant());
        public static readonly OrderStatus Finalized = new OrderStatus(5, nameof(Finalized).ToLowerInvariant());
        
        private OrderStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}