using System;
using Orders.Domain.SeedWork;

namespace Orders.Domain.Model
{
    public class OrderLine : Entity
    {
        public OrderLine(string description, decimal unitPrice, decimal amount)
        {
            if (unitPrice <= 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

            Description = description ?? throw new ArgumentNullException(nameof(description));
            UnitPrice = unitPrice;
            Amount = amount;
        }

        public string Description { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Amount { get; private set; }

        public decimal Total => UnitPrice * Amount;
    }
}