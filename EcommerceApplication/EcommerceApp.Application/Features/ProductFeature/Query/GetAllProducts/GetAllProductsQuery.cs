using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Query.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}