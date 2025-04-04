using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.CreateProduct
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategory, int>
    {
        private readonly IProductRepository _productRepository;

        public AddCategoryCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(AddCategory request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                PictureUrl = request.PictureUrl,
                CategoryId = request.CategoryId
            };

            await _productRepository.AddAsync(product);
            return product.Id; // Return the created product's Id
        }
    }
}

