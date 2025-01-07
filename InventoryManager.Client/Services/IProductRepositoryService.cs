using InventoryManager.Models.Domain;

namespace InventoryManager.Client.Services
{
    public interface IProductRepositoryService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<int> GetTotalProducts();
        public Task<Product> GetProductById(string Id);
    }
}
