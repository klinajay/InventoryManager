using InventoryManager.Contracts.Repositories;
using InventoryManager.Contracts.Services;
using InventoryManager.Models.Domain;

namespace InventoryManager.Services
{
    public class SupplierRepositoryService : ISupplierRepositoryService
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
        public async Task<Supplier> GetSupplierById(string Id)
        {
            Supplier supplierSellected = default!;
            supplierSellected = await _supplierRepository.GetSupplierById(Id);
            return supplierSellected;
            //return _supplierRepository.GetSupplierById(Id);
        }
    }
}
