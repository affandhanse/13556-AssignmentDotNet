using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Query.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<ProductCategory>>
    {
    }
}
