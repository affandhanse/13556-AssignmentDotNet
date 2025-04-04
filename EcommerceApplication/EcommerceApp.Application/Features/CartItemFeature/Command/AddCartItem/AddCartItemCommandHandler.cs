using EcommerceApp.Application.Features.CartItemFeature.Command.AddCartItem;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApplication.Application.Features.CartFeature.Command.AddCommand
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.AddCartItemAsync(request.UserId, request.Quantity, request.ProductId);
        }
    }
}