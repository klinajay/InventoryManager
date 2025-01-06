using InventoryManager.Contracts.Repositories;
using InventoryManager.Models.Domain;

namespace InventoryManager.Services
{
    public class SupplierRepositoryService : ISupplierRepository
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierRepositoryService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _supplierRepository.GetAllSuppliers();
        }
        public async Task<int> GetTotalSuppliers()
        {
            return await _supplierRepository.GetTotalSuppliers();
        }
    }
}
