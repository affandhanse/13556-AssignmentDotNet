using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Features.OrderItemFeature.Query.GetOrderItemById;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Features.OrderItemFeature.Query.GetOrderItems
{
    public class GetOrderItemByIdQueryHandler
    {
        private readonly IOrderItemRepository _repository;

        public GetOrderItemByIdQueryHandler(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderItem> Handle(GetOrderItemByIdQuery query)
        {
            return await _repository.GetOrderItemByIdAsync(query.OrderItemId);
        }
    }
}
