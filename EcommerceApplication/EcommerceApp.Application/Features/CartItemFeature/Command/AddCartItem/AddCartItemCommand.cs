using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Command.AddCartItem
{
    public class AddCartItemCommand : IRequest<CartItem>
    {
        public string UserId { get; set; } //will override this
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
