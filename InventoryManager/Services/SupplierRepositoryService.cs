using InventoryManager.Contracts.Repositories;
using InventoryManager.Contracts.Services;
using InventoryManager.Data;
using InventoryManager.Models.Domain;
using InventoryManager.Repositories;
using Serilog;

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
        public async Task<Supplier> GetSupplierById(String Id)
        {
            Supplier supplierSellected = default!;
            supplierSellected = await _supplierRepository.GetSupplierById(Id);
            return supplierSellected;
            //return _supplierRepository.GetSupplierById(Id);
        }
        public string GetIdForSupplier()
        {
            string lastSupplierId = _supplierRepository.GetLastSupplierId();
            string number = lastSupplierId.Substring(1);
            Int32.TryParse(number, out int idNumber);
            string supplierId = "S" + (idNumber + 1);
            return supplierId;
        }
        public async Task<bool> AddSupplier(Supplier inputSupplier)
        {
            string supplierId = GetIdForSupplier();
            bool status = await _supplierRepository.AddSupplier(inputSupplier, supplierId);
            return status;
        }
        public async Task<bool> DeleteSupplier(string Id)
        {
            bool status = await _supplierRepository.DeleteSupplier(Id);
            return status;
        }

    }
}
