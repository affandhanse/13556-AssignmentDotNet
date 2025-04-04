using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.AddCategory
{
    public class AddCategoryCommand : IRequest<ProductCategory>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
