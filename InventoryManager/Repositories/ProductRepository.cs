using InventoryManager.Contracts.Repositories;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(IDbContextFactory<AppDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _appDbContext.Products.Select(p => p).ToListAsync();
        }
        public void Dispose() {
            _appDbContext.Dispose();
        }   
    }
}
