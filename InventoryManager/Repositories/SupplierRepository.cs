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
            IEnumerable<Supplier> suppliers = default!;
            return suppliers;
        }
        public async Task<int> GetTotalSuppliers()
        {
            try
            {
                int totalSuppliers = default;
                return totalSuppliers;
            }
            catch (Exception ex)
            {
                Log.Error("Something went wrong.", ex);
                return 0;
            }
        }
        public async Task<Supplier> GetSupplierById(string Id)
        {
            Supplier selectedSupplier = default!;

            //selectedSupplier = await _appDbContext.Suppliers.;
            return selectedSupplier;
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }

    }
}
