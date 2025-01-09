using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Services
{
    public interface ISupplierRepositoryService
    {
        public Task<IEnumerable<Supplier>> GetAllSuppliers();
        public Task<int> GetTotalSuppliers();
        public Task<Supplier> GetSupplierById(string Id);
        public Task<bool> AddSupplier(Supplier inputSupplier);
        public Task<bool> DeleteSupplier(string Id);
    }
}
