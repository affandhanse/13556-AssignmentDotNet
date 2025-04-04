using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Interface
{
        public interface IProductRepository
        {
            Task<Product> GetProductByIdAsync(int id);

            Task<IEnumerable<Product>> GetAllProductAsync();

            Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);

            Task AddAsync(Product product);

            Task UpdateAsync(Product product);

            Task DeleteAsync(int id);
        }
}
