using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using MediatR;

namespace EcommerceApp.Application.Features.OrderFeature.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Orders>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Orders> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Orders
            {
                Id = request.Id,
                Status = request.Status,
                TotalAmount = request.TotalAmount
            };

            return await _orderRepository.UpdateOrderAsync(request.Id, order);
        }
    }
}
