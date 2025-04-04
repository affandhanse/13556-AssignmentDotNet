using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repository
{
        public class CartRepository : ICartRepository
        {
            private readonly ECommerceDbContext _context;

            public CartRepository(ECommerceDbContext context)
            {
                _context = context;
            }

            public async Task<CartItem> GetCartItemByIdAsync(int cartItemId)
            {
                return await _context.CartItems
                    .Include(c => c.Product) // Assuming CartItem has a navigation property to Product
                    .FirstOrDefaultAsync(c => c.Id == cartItemId);
            }

            public async Task<CartItem> AddCartItemAsync(string userId, int quantity, int productId)
            {
                var cartItem = new CartItem
                {
                    UserId = userId,
                    Quantity = quantity,
                    ProductId = productId
                };

                await _context.CartItems.AddAsync(cartItem);
                await _context.SaveChangesAsync();
                return cartItem;
            }

            public async Task<CartItem> UpdateCartItemAsync(int cartItemId, CartItem cartItem)
            {
                var existingCartItem = await GetCartItemByIdAsync(cartItemId);
                if (existingCartItem == null)
                {
                    throw new ArgumentException("Cart item not found");
                }

                existingCartItem.Quantity = cartItem.Quantity; // Update the quantity or any other properties as needed
                _context.CartItems.Update(existingCartItem);
                await _context.SaveChangesAsync();
                return existingCartItem;
            }

            public async Task<bool> DeleteCartItemAsync(int cartItemId)
            {
                var cartItem = await GetCartItemByIdAsync(cartItemId);
                if (cartItem == null)
                {
                    return false; // Item not found
                }

                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
                return true; // Successfully deleted
            }

            public async Task<IEnumerable<CartItem>> GetCartItemsAsync(string userId)
            {
                return await _context.CartItems
                    .Include(c => c.Product) // Assuming CartItem has a navigation property to Product
                    .Where(c => c.UserId.Equals(userId))
                    .ToListAsync();
            }
        }
}
