using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Services
{
    public interface IProductRepositoryService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<int> GetTotalProducts();
        public  Task<Product> GetProductById(string Id);
        public Task<bool> UpdateProduct(Product responseProduct);
    }
}
