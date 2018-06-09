using System;
using Orders.Domain.SeedWork;

namespace Orders.Domain.Model
{
    public sealed class Customer : Entity
    {
        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; private set; }
    }
}