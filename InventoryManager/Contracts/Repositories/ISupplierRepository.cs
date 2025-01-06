using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Repositories
{
    public interface ISupplierRepository
    {
        public Task<IEnumerable<Supplier>> GetAllSuppliers();
        public Task<int> GetTotalSuppliers();
    }
}
