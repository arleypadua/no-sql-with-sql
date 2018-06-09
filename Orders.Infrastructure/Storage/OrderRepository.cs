using Nevermore;
using Nevermore.Mapping;
using Nevermore.RelatedDocuments;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Orders.Domain.Model;
using System;
using System.Threading.Tasks;

namespace Orders.Infrastructure.Storage
{
    public class OrderRepository : IOrderRepository
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            ContractResolver = new PrivateSetterContractResolver()
        };
        
        internal readonly RelationalStore Store;
        internal readonly RelationalMappings Mappings;

        public OrderRepository(string connectionString)
        {
            Mappings = new RelationalMappings();
            Mappings.Install(new[] { new OrderMap() });

            Store = new RelationalStore(connectionString,
                "OrderService",
                new SqlCommandFactory(),
                Mappings,
                Settings,
                new EmptyRelatedDocumentStore());
        }

        public Task Add(Order order)
        { 
            return RunAsync(() => {
                using (var transaction = Store.BeginTransaction())
                {
                    transaction.Insert(order);
                    transaction.Commit();
                }
            });
        }

        public Task Update(Order order)
        {
            return RunAsync(() => {
                using (var transaction = Store.BeginTransaction())
                {
                    transaction.Update(order);
                    transaction.Commit();
                }
            });
        }

        public Task<Order> GetById(string id)
        {
            return RunAndReturnAsync(() =>
            {
                Order order;

                using (var transaction = Store.BeginTransaction())
                {
                    order = transaction.Load<Order>(id);
                }

                return order;
            });
        }

        private Task RunAsync(Action action)
        {
            return Task.Run(action);
        }

        private Task<T> RunAndReturnAsync<T>(Func<T> action)
        {
            return Task.Run(action);
        }
    }
}