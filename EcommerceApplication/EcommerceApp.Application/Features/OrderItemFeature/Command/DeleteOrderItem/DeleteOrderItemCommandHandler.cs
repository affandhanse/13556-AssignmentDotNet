using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;

namespace EcommerceApp.Application.Features.OrderItemFeature.Command.DeleteOrderItem
{
    public class DeleteOrderItemCommandHandler
    {
        private readonly IOrderItemRepository _repository;

        public DeleteOrderItemCommandHandler(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderItemCommand command)
        {
            return await _repository.DeleteOrderItemAsync(command);
        }
    }
}
