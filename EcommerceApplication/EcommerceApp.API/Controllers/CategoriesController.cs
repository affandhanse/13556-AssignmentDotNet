using Microsoft.AspNetCore.Mvc;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;
using EcommerceApp.Application.Features.ProductFeature.Command.AddCategory;
using EcommerceApp.Application.Features.ProductFeature.Command.DeleteCategory;
using EcommerceApp.Application.Features.ProductFeature.Command.UpdateCategory;
using EcommerceApp.Application.Features.ProductFeature.Query.GetCategoryById;
using EcommerceApp.Application.Features.ProductFeature.Query.GetAllCategories;

namespace EcommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var category = await _mediator.Send(query);
            return category != null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            var createdCategory = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            var updatedCategory = await _mediator.Send(command);
            return updatedCategory != null ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}