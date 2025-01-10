using InventoryManager.Contracts.Repositories;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            suppliers = await _appDbContext.Suppliers.Select(supplier => supplier).ToListAsync();
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
            selectedSupplier = await _appDbContext.Suppliers.FirstOrDefaultAsync(supplier => supplier.SupplierId == Id);
            return selectedSupplier;
        }
       

        public async Task<bool> AddSupplier(Supplier inputSupplier, string supplierId)
        {
            if (inputSupplier == null)
            {
                Log.Information("Provided product is null.");
                return false;
            }
            inputSupplier.SupplierId = supplierId;
            await _appDbContext.Suppliers.AddAsync(inputSupplier);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public string GetLastSupplierId()
        {
            string supplierId = _appDbContext.Suppliers.Max(supplier => supplier.SupplierId);
            return supplierId;
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }
        public async Task<bool> DeleteSupplier(string Id)
        {
            if (Id.IsNullOrEmpty())
            {
                Log.Information("Provided supplier id is null.");
                return false;
            }

            Supplier? existingSupplier = await _appDbContext.Suppliers.FindAsync(Id);

            if (existingSupplier != null)
            {
                _appDbContext.Suppliers.Remove(existingSupplier);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            Log.Information("Supplier not found.");
            return false;
        }

    }
}
