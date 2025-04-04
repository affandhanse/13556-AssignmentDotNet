using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Features.OrderItemFeature.Command.CreateOrderItem;
using EcommerceApp.Application.Features.OrderItemFeature.Command.DeleteOrderItem;
using EcommerceApp.Application.Features.OrderItemFeature.Command.UpdateOrderItem;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Interface
{
        public interface IOrderItemRepository
    {
        Task<OrderItem> AddOrderItemAsync(CreateOrderItemCommand command);
        Task<OrderItem> UpdateOrderItemAsync(UpdateOrderItemCommand command);
        Task<bool> DeleteOrderItemAsync(DeleteOrderItemCommand command);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId);
    }
}
