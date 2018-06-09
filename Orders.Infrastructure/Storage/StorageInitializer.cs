using System.Text;
using Nevermore;

namespace Orders.Infrastructure.Storage
{
    public static class StorageInitializer
    {
        public static void Initialize(string connectionString)
        {
            TransientFaultHandling.InitializeRetryManager();

            // Setup the database
            DbUp.DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssemblies(new[] {
                    typeof(RelationalStore).Assembly, // Contains the Nevermore required script
                    typeof(StorageInitializer).Assembly  // Your scripts
                })
                .WithScript("schema-startup", CreateStartupSchema(connectionString))
                .Build()
                .PerformUpgrade();
        }

        private static string CreateStartupSchema(string connectionString)
        {
            var repository = new OrderRepository(connectionString);

            StringBuilder output = new StringBuilder();

            foreach (var map in repository.Mappings.GetAll())
                SchemaGenerator.WriteTableSchema(map, null, output);

            return output.ToString();
        }
    }
}