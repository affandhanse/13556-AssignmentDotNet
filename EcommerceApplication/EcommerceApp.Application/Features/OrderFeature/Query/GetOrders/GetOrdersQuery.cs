using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.OrderFeature.Query.GetOrders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Orders>>
    {
    }
}
