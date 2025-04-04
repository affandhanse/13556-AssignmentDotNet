using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Command.UpdateCartItem
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem { Quantity = request.Quantity }; // Create a new CartItem object for update
            return await _cartRepository.UpdateCartItemAsync(request.CartItemId, cartItem);
        }
    }
}
