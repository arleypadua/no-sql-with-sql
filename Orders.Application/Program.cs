using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Domain.Model;
using Orders.Infrastructure.Storage;

namespace Orders.Application
{
    class Program
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DocumentStorage;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static Program()
        {
            StorageInitializer.Initialize(ConnectionString);
        }

        // This can be easily refactored in order to get the instance from an IoC container
        // For the matter of this learning, lets keep it simple.
        // TODO: put the implementation when it is available.
        private static readonly IOrderRepository OrderRepository = new OrderRepository(ConnectionString);

        static void Main(string[] args) => new Application(OrderRepository)
            .RunAsync()
            .GetAwaiter()
            .GetResult();
        
    }
}
