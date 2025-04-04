using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities.Constants;
using EcommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (request == null || request.Quantity <= 0 || request.ProductId <= 0)
            {
                return BadRequest("Invalid order data.");
            }

            var order = await _orderRepository.AddOrderAsync(request.UserId, request.Quantity, request.ProductId);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return Ok(orders);
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Orders>> UpdateOrder(int id, [FromBody] UpdateOrderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid order data.");
            }

            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.Status = request.Status; // Assuming Status is part of the request
            existingOrder.TotalAmount = request.TotalAmount; // Assuming TotalAmount is part of the request

            var updatedOrder = await _orderRepository.UpdateOrderAsync(id, existingOrder);
            return Ok(updatedOrder);
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteOrderAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    // Request models for creating and updating orders
    public class CreateOrderRequest
    {
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateOrderRequest
    {
        public Status Status { get; set; } // Assuming Status is an enum or a class
        public decimal TotalAmount { get; set; }
    }
}
