using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Query.GetCartItemById
{
    public class GetCartItemByIdQueryHandler : IRequestHandler<GetCartItemByIdQuery, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemByIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartItemByIdAsync(request.CartItemId);
        }
    }
}
