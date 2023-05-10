using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CountPad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController:ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async ValueTask<ActionResult> PostOrderAsync(Order order)
        {
            var response= await _orderService.AddOrderAsync(order);
            return Ok(response);
        }

        [HttpGet("{id")]
        public async ValueTask<ActionResult> GetOrderByIdAsync(Guid guid)
        {
            var response= await _orderService.DeleteOrderAsync(guid);
            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<ActionResult> GetAllOrdersAsync()
        {
            IQueryable<Order> response=  _orderService.GetAllOrdersAsync();
            return Ok(response);
        }

        [HttpPut]
        public async ValueTask<ActionResult> UpdateOrderAsync(Order order)
        {
            var response = await _orderService.UpdateOrderAsync(order);
            return Ok(response);
        }

        [HttpDelete]
        public async ValueTask<ActionResult> DeleteOrderAsync(Guid id)
        {
            var response= await _orderService.DeleteOrderAsync(id);
            return Ok(response);
        }
    }
}
