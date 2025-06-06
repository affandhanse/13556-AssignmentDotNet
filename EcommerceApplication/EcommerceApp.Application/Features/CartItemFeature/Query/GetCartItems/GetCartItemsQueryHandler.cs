﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Query.GetCartItems
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, IEnumerable<CartItem>>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<CartItem>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartItemsAsync(request.UserId);
        }
    }
}
