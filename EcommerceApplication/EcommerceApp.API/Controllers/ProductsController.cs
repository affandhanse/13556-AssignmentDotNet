using MediatR;
using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Features.ProductFeature.Command.CreateProduct;
using EcommerceApp.Application.Features.ProductFeature.Command.UpdateProduct;
using EcommerceApp.Application.Features.ProductFeature.Command.DeleteProduct;
using EcommerceApp.Application.Features.ProductFeature.Query.GetProductsByCategoryId;
using EcommerceApp.Application.Features.ProductFeature.Query.GetAllProducts;
using EcommerceApp.Application.Features.ProductFeature.Query.GetProductById;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var product = await _mediator.Send(query);
            return product != null ? Ok(product) : NotFound();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQuery(); 
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var query = new GetProductsByCategoryIdQuery { CategoryId = categoryId }; 
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] AddCategory command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command) 
        {
            if (id != command.Id)
            {
                return BadRequest("Product ID Not Found...");
            }

            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand { Id = id }; 
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}