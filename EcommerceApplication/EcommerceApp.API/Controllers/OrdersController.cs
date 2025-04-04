using EcommerceApp.Application.Features.OrderFeature.Command.CreateOrder;
using EcommerceApp.Application.Features.OrderFeature.Command.DeleteOrder;
using EcommerceApp.Application.Features.OrderFeature.Command.UpdateOrder;
using EcommerceApp.Application.Features.OrderFeature.Query.GetOrderById;
using EcommerceApp.Application.Features.OrderFeature.Query.GetOrders;
using EcommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Orders>> UpdateOrder(int id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.Id) return BadRequest();
            var updatedOrder = await _mediator.Send(command);
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand { Id = id });
            if (!result) return NotFound();
            return NoContent();
        }
    }
}



   