using AzureCosmosDemoApp.Models;
using AzureCosmosDemoApp.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeranetHackathon.HubConfig;
using TeranetHackathon.Models;

namespace AzureCosmosDemoApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private IHubContext<ChartHub> _hub;
        public OrdersController(IOrderService orderService, IHubContext<ChartHub> hub)
        {
            _orderService = orderService;
            _hub = hub;
        }
       [HttpGet]
        public async Task<IEnumerable<ChartModel>> GetOrderTypeChart()
        {
           var orders =  await _orderService.GetOrdersAsync("SELECT * FROM c");
            var registration = orders.Count(x => x.OrderTypeId == 1);
            var search = orders.Count(x => x.OrderTypeId == 2);
            var change = orders.Count(x => x.OrderTypeId == 3);
            var renewal = orders.Count(x => x.OrderTypeId == 4);
            var discharge = orders.Count(x => x.OrderTypeId == 5);
            List<ChartModel> chartModels = new List<ChartModel>();
            chartModels.Add(new ChartModel { Data = new List<int> { registration }, Label = "Registration" });
            chartModels.Add(new ChartModel { Data = new List<int> { search }, Label = "Search" });
            chartModels.Add(new ChartModel { Data = new List<int> { change }, Label = "Change" });
            chartModels.Add(new ChartModel { Data = new List<int> { renewal }, Label = "Renewal" });
            chartModels.Add(new ChartModel { Data = new List<int> { discharge }, Label = "Discharge" });
            return chartModels;
        }
        [HttpGet]
        public async Task<IEnumerable<int>> GetOrderTypeChartForPie()
        {
            var orders = await _orderService.GetOrdersAsync("SELECT * FROM c");
            var registration = orders.Count(x => x.OrderTypeId == 1);
            var search = orders.Count(x => x.OrderTypeId == 2);
            var change = orders.Count(x => x.OrderTypeId == 3);
            var renewal = orders.Count(x => x.OrderTypeId == 4);
            var discharge = orders.Count(x => x.OrderTypeId == 5);
            List<int> data = new List<int>();
            data.Add(registration);
            data.Add(search);
            data.Add(change);
            data.Add(renewal);
            data.Add(discharge);
            return data;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartModel>>> GetOrderStatusChart()
        {
           var orders= await _orderService.GetOrdersAsync("SELECT * FROM c");
            var draft = orders.Count(x => x.OrderStatusId == 1);
            var inprogress = orders.Count(x => x.OrderStatusId == 2);
            var completed = orders.Count(x => x.OrderStatusId == 3);
            var cancelled = orders.Count(x => x.OrderStatusId == 4);
            List<ChartModel> chartModels = new List<ChartModel>();
            chartModels.Add(new ChartModel { Data = new List<int> { draft }, Label = "Draft" });
            chartModels.Add(new ChartModel { Data = new List<int> { inprogress }, Label = "In-Progress" });
            chartModels.Add(new ChartModel { Data = new List<int> { completed }, Label = "Completed" });
            chartModels.Add(new ChartModel { Data = new List<int> { cancelled }, Label = "Cancelled" });
            return chartModels;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChartModel>>> GetRegistrationChartByDate()
        {
            var orders = await _orderService.GetOrdersAsync("SELECT * FROM c");
            var regJan = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month==1);
            var regFeb = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 2);
            var regMar = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 3);
            var regApr = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 4);
            var regMay = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 5);
            var regJun = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 6);
            var regJul = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 7);
            var regAug = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 8);
            var regSep = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 9);
            var regOct = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 10);
            var regNov = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 11);
            var regDec = orders.Count(x => x.OrderTypeId == 1 && x.SubmissionDate.Month == 12);
           
            List<ChartModel> chartModels = new List<ChartModel>();
             chartModels.Add(new ChartModel { Data = new List<int> { regJan, regFeb,regMar,regApr,regMay,regJun,regJul,regAug,regSep,regOct,regNov,regDec }, Label = "Registration" });
          
            return chartModels;
        }
        [HttpPost]
       
        public async Task CreateAsync(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid().ToString();
                await _orderService.AddOrderAsync(order);
                await _hub.Clients.All.SendAsync("transferchartdata", new List<ChartModel>());
            }

            
        }
    }
}
