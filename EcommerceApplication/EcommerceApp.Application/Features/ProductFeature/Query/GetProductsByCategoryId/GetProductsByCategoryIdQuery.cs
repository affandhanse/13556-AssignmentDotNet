using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Query.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<Product>>
    {
        public int CategoryId { get; set; } // Category ID to filter products
    }
}
