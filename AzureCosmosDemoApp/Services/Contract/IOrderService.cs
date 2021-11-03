using AzureCosmosDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureCosmosDemoApp.Services.Contract
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync(string query);
        Task AddOrderAsync(Order order);
    }
}
