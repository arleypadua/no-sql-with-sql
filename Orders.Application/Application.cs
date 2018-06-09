using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Domain.Model;
using Orders.Infrastructure.Storage;

namespace Orders.Application
{
    public class Application
    {
        private readonly IOrderRepository _repository;

        public Application(IOrderRepository repository)
        {
            _repository = repository;
        }
        
        public async Task RunAsync()
        {
            var id = await CreateOrder();

            await SetOrderApproved(id);
            await SetOrderPayed(id);
            await SetOrderCanceled(id);
        }

        private async Task<string> CreateOrder()
        {
            var newOrder = Order.New(new Customer("John"), new List<OrderLine>
            {
                new OrderLine("Product 1", 10, 1),
                new OrderLine("Product 2", 15, 3),
                new OrderLine("Product 3", 1, 25),
            });

            await _repository.Add(newOrder);

            return newOrder.Id;
        }

        private async Task SetOrderApproved(string id)
        {
            var order = await _repository.GetById(id);
            order.SetApproved("approved, pay attention at the second product.");

            await _repository.Update(order);
        }

        private async Task SetOrderPayed(string id)
        {
            var order = await _repository.GetById(id);
            order.SetPayed();

            await _repository.Update(order);
        }

        private async Task SetOrderCanceled(string id)
        {
            var order = await _repository.GetById(id);
            order.SetCanceled("The payment was declined by the provider");

            await _repository.Update(order);
        }
    }
}