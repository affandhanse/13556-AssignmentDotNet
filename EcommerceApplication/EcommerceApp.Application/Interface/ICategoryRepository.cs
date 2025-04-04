using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Domain.Entities;

namespace EcommerceApp.Application.Interface
{
        public interface ICategoryRepository
        {
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<ProductCategory> GetCategoryByIdAsync(int id);
        Task<ProductCategory> AddCategoryAsync(ProductCategory category);
        Task<ProductCategory> UpdateCategoryAsync(int Id, ProductCategory productCategory);
        Task<bool> DeleteCategoryAsync(int id);
        }
}
