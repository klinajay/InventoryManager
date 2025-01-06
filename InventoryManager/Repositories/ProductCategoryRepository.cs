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
            IEnumerable<ProductCategory> productCategories = (IEnumerable<ProductCategory>) await _appDbContext.ProductCategories.Select(category => category).ToListAsync();
            return productCategories;
        }
        public async Task<int> GetTotalCategories()
        {
            try
            {
                int totalCategories = await _appDbContext.ProductCategories.CountAsync();
                return totalCategories;
            }
            catch (Exception ex)
            {
                Log.Error("Something went wrong.", ex);
                return 0;
            }
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }

    }
}
