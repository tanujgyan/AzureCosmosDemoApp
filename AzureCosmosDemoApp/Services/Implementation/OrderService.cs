using AzureCosmosDemoApp.Models;
using AzureCosmosDemoApp.Services.Contract;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureCosmosDemoApp.Services
{
    public class OrderService: IOrderService
    {
        private Container _container;

        public OrderService(CosmosClient dbClient, string databaseName, string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddOrderAsync(Order order)
        {
            await this._container.CreateItemAsync<Order>(order, new PartitionKey(order.Id));
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Order>(new QueryDefinition(queryString));
            List<Order> results = new List<Order>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
    }
}
