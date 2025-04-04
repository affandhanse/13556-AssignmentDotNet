using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ProductCategory>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductCategory> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new ProductCategory { Id = request.Id, Name = request.Name, Description = request.Description };
            return await _categoryRepository.UpdateCategoryAsync(request.Id, category);
        }
    }
}

