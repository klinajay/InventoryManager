using InventoryManager.Models.Domain;

namespace InventoryManager.Contracts.Services
{
    public interface IProductCategoryRepositoryService
    {
        public Task<IEnumerable<ProductCategory>> GetAllCategories();
        public Task<int> GetTotalCategories();
    }
}
