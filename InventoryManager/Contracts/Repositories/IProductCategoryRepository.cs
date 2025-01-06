using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Repositories
{
    public interface IProductCategoryRepository
    {
        public Task<IEnumerable<ProductCategory>> GetAllCategories();
        public Task<int> GetTotalCategories();
    }
}
