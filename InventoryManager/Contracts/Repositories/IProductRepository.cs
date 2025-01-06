using InventoryManager.Data;
using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Repositories
{
    public interface IProductRepository
    {
        

        public  Task<IEnumerable<Product>>  GetAllProducts();
        public Task<int> GetTotalProducts();
    }
}
