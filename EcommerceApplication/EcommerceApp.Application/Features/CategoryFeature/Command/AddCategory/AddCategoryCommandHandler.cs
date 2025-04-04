using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, ProductCategory>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductCategory> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new ProductCategory { Name = request.Name, Description = request.Description };
            return await _categoryRepository.AddCategoryAsync(category);
        }
    }
}

