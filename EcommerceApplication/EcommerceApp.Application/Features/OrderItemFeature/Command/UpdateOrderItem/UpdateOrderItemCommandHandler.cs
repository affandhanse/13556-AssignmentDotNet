using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Features.OrderItemFeature.Command.UpdateOrderItem
{
    public class UpdateOrderItemCommandHandler
    {
        private readonly IOrderItemRepository _repository;

        public UpdateOrderItemCommandHandler(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderItem> Handle(UpdateOrderItemCommand command)
        {
            return await _repository.UpdateOrderItemAsync(command);
        }
    }
}
