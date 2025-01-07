using InventoryManager.Models.Domain;

namespace InventoryManager.Client.Services
{
    public interface IProductRepositoryClientService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<int> GetTotalProducts();
        public Task<Product> GetProductById(string Id);
    }
}
