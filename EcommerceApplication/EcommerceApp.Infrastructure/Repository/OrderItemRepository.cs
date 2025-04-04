using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Application.Features.OrderItemFeature.Command.CreateOrderItem;
using EcommerceApp.Application.Features.OrderItemFeature.Command.DeleteOrderItem;
using EcommerceApp.Application.Features.OrderItemFeature.Command.UpdateOrderItem;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderItemRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        // Query: Get all order items for a specific order
        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        // Query: Get a specific order item by ID
        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _context.OrderItems.FindAsync(orderItemId);
        }

        // Command: Add a new order item
        public async Task<OrderItem> AddOrderItemAsync(CreateOrderItemCommand command)
        {
            var orderItem = new OrderItem
            {
                OrderId = command.OrderId,
                ProductId = command.ProductId,
                Quantity = command.Quantity
            };

            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        // Command: Update an existing order item
        public async Task<OrderItem> UpdateOrderItemAsync(UpdateOrderItemCommand command)
        {
            var existingOrderItem = await GetOrderItemByIdAsync(command.OrderItemId);
            if (existingOrderItem == null)
            {
                throw new ArgumentException("Order item not found.");
            }

            existingOrderItem.Quantity = command.Quantity;
            existingOrderItem.ProductId = command.ProductId;

            _context.OrderItems.Update(existingOrderItem);
            await _context.SaveChangesAsync();

            return existingOrderItem;
        }

        // Command: Delete an order item
        public async Task<bool> DeleteOrderItemAsync(DeleteOrderItemCommand command)
        {
            var orderItem = await GetOrderItemByIdAsync(command.OrderItemId);
            if (orderItem == null)
            {
                return false; // Item not found
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true; // Successfully deleted
        }
    }
}