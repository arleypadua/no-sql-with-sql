using System.Collections.Generic;
using Orders.Domain.SeedWork;
using System.Threading.Tasks;

namespace Orders.Domain.Model
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task Add(Order order);
        Task Update(Order order);
        Task<Order> GetById(string id);
        Task<List<Order>> GetByCustomerName(string name);
    }
}