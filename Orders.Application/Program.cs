using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Domain.Model;

namespace Orders.Application
{
    class Program
    {
        
        static void Main(string[] args) => new Application()
            .RunAsync()
            .GetAwaiter()
            .GetResult();
        
    }
}
