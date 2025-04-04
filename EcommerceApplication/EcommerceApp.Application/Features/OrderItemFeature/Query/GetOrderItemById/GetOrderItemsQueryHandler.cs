using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Features.OrderItemFeature.Query.GetOrderItems;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Features.OrderItemFeature.Query.GetOrderItemById
{
    public class GetOrderItemsQueryHandler
    {
        private readonly IOrderItemRepository _repository;

        public GetOrderItemsQueryHandler(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetOrderItemsQuery query)
        {
            return await _repository.GetOrderItemsAsync(query.OrderId);
        }
    }
}
