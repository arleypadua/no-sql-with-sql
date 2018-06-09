using System;
using System.Threading.Tasks;
using Orders.Domain.SeedWork;

namespace Orders.Domain.Model
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task Add(Order order);
        Task Update(Order order);
        Task<Order> GetById(Guid id);
    }
}