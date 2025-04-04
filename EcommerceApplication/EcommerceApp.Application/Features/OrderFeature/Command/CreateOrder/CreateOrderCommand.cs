using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.OrderFeature.Command.CreateOrder
{
    public class CreateOrderCommand : IRequest<Orders>
    {
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
