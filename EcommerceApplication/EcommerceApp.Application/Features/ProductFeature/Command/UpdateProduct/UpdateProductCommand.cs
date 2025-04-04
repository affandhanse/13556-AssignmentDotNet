using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; } // Product ID to update
        public string Name { get; set; }
        public double Price { get; set; }
        public string PictureUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
