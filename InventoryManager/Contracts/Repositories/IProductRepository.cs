using InventoryManager.Data;
using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Repositories
{
    public interface IProductRepository
    {

        public  Task<IEnumerable<Product>>  GetAllProducts();
        public Task<int> GetTotalProducts();
        public Task<Product> GetProductById(string Id);
        public  Task<bool> UpdateProduct(Product responseProduct);
        public Task<bool> DeleteProduct(string Id);
    }
}
