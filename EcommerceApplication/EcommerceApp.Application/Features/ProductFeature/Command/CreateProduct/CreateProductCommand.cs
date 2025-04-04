using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace EcommerceApp.Application.Features.ProductFeature.Command.CreateProduct
{
    public class AddCategory : IRequest<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string PictureUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
