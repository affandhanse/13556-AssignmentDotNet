using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Entities.Constants;
using EcommerceApp.Application.Features.OrderItemFeature.Command.CreateOrderItem; // Ensure this namespace is correct
using EcommerceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext _context;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderRepository(ECommerceDbContext context, IOrderItemRepository orderItemRepository)
        {
            _context = context;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Orders> AddOrderAsync(string userId, int quantity, int productId)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0.");
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            if (quantity > product.Stock)
            {
                throw new InvalidOperationException("Insufficient stock available for the requested product.");
            }

            var order = new Orders
            {
                UserId = userId,
                TotalAmount = quantity * (decimal)product.Price,
                OrderDate = DateTime.Now,
                Status = Status.Pending
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Create the command object for the order item
            var createOrderItemCommand = new CreateOrderItemCommand
            {
                OrderId = order.Id, // Assuming Id is the primary key in Orders
                ProductId = productId,
                Quantity = quantity
            };

            // Use the order item repository to add the order item
            await _orderItemRepository.AddOrderItemAsync(createOrderItemCommand);

            // Update the product stock
            product.Stock -= quantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id); // Assuming Id is the primary key in Orders
        }

        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            return await _context.Orders
                .ToListAsync();
        }

        public async Task<Orders> UpdateOrderAsync(int id, Orders order)
        {
            var existingOrder = await GetOrderByIdAsync(id);
            if (existingOrder == null)
            {
                throw new ArgumentException("Order not found.");
            }

            existingOrder.Status = order.Status;
            existingOrder.TotalAmount = order.TotalAmount;

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();

            return existingOrder;
        }
    }
}