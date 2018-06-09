using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Domain.Model;

namespace Orders.Application
{
    class Program
    {
        static void Main(string[] args) => RunAsync(args).GetAwaiter().GetResult();

        static Task RunAsync(string[] args)
        {
            return Task.CompletedTask;
        }
    }
}
