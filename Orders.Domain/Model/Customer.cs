using System;

namespace Orders.Domain.Model
{
    public sealed class Customer
    {
        public Customer(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; private set; }
    }
}