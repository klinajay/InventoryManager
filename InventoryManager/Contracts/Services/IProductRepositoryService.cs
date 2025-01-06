using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Services
{
    public interface IProductRepositoryService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<int> GetTotalProducts();
    }
}
