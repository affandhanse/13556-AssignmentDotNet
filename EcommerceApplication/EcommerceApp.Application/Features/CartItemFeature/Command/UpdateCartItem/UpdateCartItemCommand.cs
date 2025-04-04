using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Command.UpdateCartItem
{
    public class UpdateCartItemCommand : IRequest<CartItem>
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
