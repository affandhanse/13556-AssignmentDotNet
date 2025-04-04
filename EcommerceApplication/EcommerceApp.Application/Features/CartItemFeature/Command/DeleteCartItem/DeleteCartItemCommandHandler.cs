using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using MediatR;

namespace EcommerceApp.Application.Features.CartItemFeature.Command.DeleteCartItem
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, bool>
    {
        private readonly ICartRepository _cartRepository;

        public DeleteCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            return await _cartRepository.DeleteCartItemAsync(request.CartItemId);
        }
    }
}
