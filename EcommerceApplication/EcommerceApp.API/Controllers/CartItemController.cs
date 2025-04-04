using MediatR;
using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Application.Features.CartItemFeature.Command.AddCartItem;
using EcommerceApp.Application.Features.CartItemFeature.Command.DeleteCartItem;
using EcommerceApp.Application.Features.CartItemFeature.Command.UpdateCartItem;
using EcommerceApp.Application.Features.CartItemFeature.Query.GetCartItemById;
using EcommerceApp.Application.Features.CartItemFeature.Query.GetCartItems;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EcommerceApp.API.Controllers
{
    [Authorize(Roles ="User")]
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/cartitem/{userId}
        [HttpGet("{jwt}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(string jwt)
        {
            var userId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in token.");
            }
            var query = new GetCartItemsQuery { UserId = userId };
            var cartItems = await _mediator.Send(query);
            return Ok(cartItems);
        }

        [HttpGet("{cartItemId:int}")]
        public async Task<ActionResult<CartItem>> GetCartItemById(int cartItemId)
        {
            var query = new GetCartItemByIdQuery { CartItemId = cartItemId };
            var cartItem = await _mediator.Send(query);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        // POST: api/cartitem
        //[HttpPost]
        //public async Task<ActionResult<CartItem>> AddCartItem([FromBody] AddCartItemCommand command)
        //{

        //    if (command == null)
        //    {
        //        return BadRequest("Invalid cart item data.");
        //    }

        //    var cartItem = await _mediator.Send(command);
        //    return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItem.Id }, cartItem);
        //}

        [HttpPost]
        public async Task<ActionResult<CartItem>> AddCartItem([FromBody] AddCartItemCommand command)
        {
            if (command == null)
                return BadRequest("Command cannot be null");

            // Get UserId from JWT claim
            var userId = User.FindFirst("uid")?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token");

            // Override any UserId that might have been sent in the request
            command.UserId = userId;

            var cartItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItem.Id }, cartItem);
        }

        // PUT: api/cartitem/{cartItemId}
        [HttpPut("{cartItemId:int}")]
        public async Task<ActionResult<CartItem>> UpdateCartItem(int cartItemId, [FromBody] UpdateCartItemCommand command)
        {
            if (command == null || command.CartItemId != cartItemId)
            {
                return BadRequest("Invalid cart item data.");
            }

            var updatedCartItem = await _mediator.Send(command);
            return Ok(updatedCartItem);
        }

        // DELETE: api/cartitem/{cartItemId}
        [HttpDelete("{cartItemId:int}")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            var command = new DeleteCartItemCommand { CartItemId = cartItemId };
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}