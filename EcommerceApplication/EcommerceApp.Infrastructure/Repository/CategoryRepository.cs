using EcommerceApp.Application.Interface;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ECommerceDbContext _context;

        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<ProductCategory> AddCategoryAsync(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<ProductCategory> UpdateCategoryAsync(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return null;
            }

            _context.Entry(productCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}



