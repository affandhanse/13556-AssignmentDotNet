using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities.Constants;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.OrderFeature.Command.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<Orders>
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
