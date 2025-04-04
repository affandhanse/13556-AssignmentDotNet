using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Features.OrderItemFeature.Command.CreateOrderItem
{
    public class CreateOrderItemCommandHandler
    {
        private readonly IOrderItemRepository _repository;

        public CreateOrderItemCommandHandler(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderItem> Handle(CreateOrderItemCommand command)
        {
            return await _repository.AddOrderItemAsync(command);
        }
    }

}
