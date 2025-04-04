using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Interface
{
    public interface ICartRepository
    {
        Task<CartItem> GetCartItemByIdAsync(int cartItemId);
        Task<CartItem> AddCartItemAsync(string userId, int quantity, int productId);
        Task<CartItem> UpdateCartItemAsync(int cartItemId, CartItem cartItem);
        Task<bool> DeleteCartItemAsync(int cartItemId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(string userId);


    }
}
