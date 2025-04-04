using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.OrderFeature.Query.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Orders>
    {
        public int Id { get; set; }
    }
}
