using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Query.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategoryIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByCategoryIdAsync(request.CategoryId);
        }
    }
}
