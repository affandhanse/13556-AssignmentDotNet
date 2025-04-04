using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.OrderFeature.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Orders>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Orders> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.AddOrderAsync(request.UserId, request.Quantity, request.ProductId);
        }
    }
}
