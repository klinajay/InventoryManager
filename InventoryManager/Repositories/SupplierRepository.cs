using InventoryManager.Contracts.Repositories;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace InventoryManager.Repositories
{
    public class SupplierRepository : ISupplierRepository , IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public SupplierRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            IEnumerable<Supplier> suppliers  = await _appDbContext.ProductCategories.Select(supplier => supplier).ToListAsync();
            return suppliers;
        }
        public async Task<int> GetTotalSuppliers()
        {
            try
            {
                int totalSuppliers = await _appDbContext.ProductCategories.CountAsync();
                return totalSuppliers;
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
