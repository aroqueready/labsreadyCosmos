
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using ready.labs.Models;

namespace ready.labs.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CosmosClient _client;
        private readonly IConfiguration _configuration;
        private readonly Container _container;
        public EmployeeRepository(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _client = cosmosClient;
            _configuration = configuration;
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var ContainerName = "Employees";
            _container = cosmosClient.GetContainer(databaseName,ContainerName);

        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var query = _container.GetItemLinqQueryable<Employee>()
                .ToFeedIterator();

            var employees = new List<Employee>();

            while (query.HasMoreResults) 
            {
                var response = await query.ReadNextAsync();
                
                employees.AddRange(response);

            }

            return employees;
        }
    }
}
