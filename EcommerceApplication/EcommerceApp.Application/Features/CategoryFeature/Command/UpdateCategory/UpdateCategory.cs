using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ProductCategory>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
