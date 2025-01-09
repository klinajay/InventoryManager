using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Repositories
{
    public interface ISupplierRepository
    {
        public Task<IEnumerable<Supplier>> GetAllSuppliers();
        public Task<int> GetTotalSuppliers();
        public  Task<Supplier> GetSupplierById(string Id);
        public Task<bool> DeleteSupplier(string Id);
        public Task<bool> AddSupplier(Supplier inputSupplier, string Id);
        public string GetLastSupplierId();
    }
}
