using InventoryManager.Contracts.Repositories;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace InventoryManager.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository , IDisposable
    {
        private readonly AppDbContext _appDbContext;
        public ProductCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllCategories()
        {
            IEnumerable<ProductCategory> productCategories = (IEnumerable<ProductCategory>) await _appDbContext.Categories.Select(category => category).ToListAsync();
            return productCategories;
        }
        public async Task<int> GetTotalCategories()
        {
            try
            {
                int totalCategories = await _appDbContext.Categories.CountAsync();
                return totalCategories;
            }
            catch (Exception ex)
            {
                Log.Error("Something went wrong.", ex);
                return 0;
            }
        }
        public async Task<ProductCategory> GetProductCategoriesById(string Id)
        {
            ProductCategory selectedProductCategory = default!;
            selectedProductCategory = await _appDbContext.Categories.FirstOrDefaultAsync(productCategory => productCategory.ProductCategoryId == Id);
            return selectedProductCategory;
        }
        public string GetIdOfCategory(string categoryName)
        {
            string? categoryId = default!;
            categoryId = _appDbContext.Categories.Where(category => category.CategoryName == categoryName).Select(category => category.CategoryName).ToString();
            return categoryId;
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }

    }
}
