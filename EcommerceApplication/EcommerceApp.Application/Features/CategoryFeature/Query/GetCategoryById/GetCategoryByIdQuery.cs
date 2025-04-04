using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Query.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<ProductCategory>
    {
        public int Id { get; set; }
    }
}
