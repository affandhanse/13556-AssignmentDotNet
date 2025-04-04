using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Interface
{
        public interface IOrderRepository
        {
        Task<IEnumerable<Orders>> GetOrdersAsync();
        Task<Orders> UpdateOrderAsync(int id, Orders order);
        Task<bool> DeleteOrderAsync(int id);
        Task<Orders> GetOrderByIdAsync(int id);
        Task<Orders> AddOrderAsync(string userId, int quantity, int productId);
        }
}
